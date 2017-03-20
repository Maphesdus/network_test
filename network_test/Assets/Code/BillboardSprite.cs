/// This script comes from the following website:
/// http://www.justinreinhart.com/2016/07/08/pixel-perfect-billboard-sprites/

// BillboardSprite.cs
using UnityEngine;
using System.Collections;

public class BillboardSprite: MonoBehaviour {
	private GameObject cam;
	private Transform MyCameraTransform;
	private Transform MyTransform;
	public bool alignNotLook = true;

	//MyTransform.LookAt (MyTransform.position + MyCameraTransform.rotation * Vector3.forward, MyCameraTransform.rotation * Vector3.up);

	// START:
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		MyTransform = this.transform;
		MyCameraTransform = cam.transform;
	}
	
	// UPDATE:
	void LateUpdate () {
		if (alignNotLook)
			MyTransform.forward = MyCameraTransform.forward;
		else
			MyTransform.LookAt (MyCameraTransform, Vector3.up);
	}
}