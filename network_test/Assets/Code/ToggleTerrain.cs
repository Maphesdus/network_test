using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTerrain : MonoBehaviour {
	public GameObject terrain;
	public bool terrainToggle = false;

	// START:
	void Start () {
		if (terrainToggle) {
			terrain.SetActive(true);
		} else
			terrain.SetActive (false);
	}

	// FIXED UPDATE:
	void FixedUpdate () {
		if (terrainToggle) {
			terrain.SetActive(true);
		} else
			terrain.SetActive (false);
	}

	// ON TRIGGER ENTER:
	void OnTriggerEnter(Collider col){
		if(terrainToggle == true){
			terrainToggle = false;
		}

		else if(terrainToggle == false){
			terrainToggle = true;
		}
	}
}