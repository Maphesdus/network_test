using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FollowTarget : MonoBehaviour {
	public float offset = 0.0f;
	public GameObject player;

	// START:
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// UPDATE:
	void Update () {
		//this.transform.position = player.transform.position - offset;
	}
}
