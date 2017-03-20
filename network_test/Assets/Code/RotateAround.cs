using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	public float speed = 20;
	
	//UPDATE:
    void Update() {
        transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.deltaTime);
    }
}