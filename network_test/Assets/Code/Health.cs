using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	public const int maxHealth = 100;
	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;
	public RectTransform healthBar;
	private NetworkStartPosition[] spawnPoints;


	// START:
	void Start () {
		if (isLocalPlayer) {
			spawnPoints = FindObjectsOfType<NetworkStartPosition>();
		}
	} // END START


	// UPDATE:
	void Update () {
		
	} // END UPDATE


	// TAKE DAMAGE:
	public void TakeDamage(int amount) {
		if (!isServer){
			return;
		}

		currentHealth -= amount;
		if (currentHealth <= 0) {
			currentHealth = maxHealth;
			RpcRespawn(); // called on the Server, but invoked on the Clients
		}
	} // END TAKE DAMAGE


	// ON CHANGE HEALTH:
	void OnChangeHealth(int health){
		healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
	} // END ON CHANGE HEALTH


	// RPC RESPAWN:
	[ClientRpc]
	void RpcRespawn() {
		if (isLocalPlayer) {
			// Set the spawn point to origin as a default value
			Vector3 spawnPoint = Vector3.zero;

			// If there is a spawn point array and the array is not empty, pick a spawn point at random
			if (spawnPoints != null && spawnPoints.Length > 0) {
				spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
			}

			// Set the player’s position to the chosen spawn point
			transform.position = spawnPoint;
		}
	}// END RPC RESPAWN
} // END CLASS HEALTH