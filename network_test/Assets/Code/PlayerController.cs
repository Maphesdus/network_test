using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour {
	public float xSpeed = 150.0f;
	public float ySpeed = 3.0f;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	private AudioSource laserSFX;
	public Vector3 cameraOffsetVector = new Vector3(0, -5, 10);
	private GameObject cam;
	[SyncVar]
	public string playerName;
	public Text playerNameTextObject;


	//START:
	void Start(){
		laserSFX = GetComponent<AudioSource>();
		cam = GameObject.FindGameObjectWithTag("MainCamera");
	} // END START
	
	
	// ON START LOCAL PLAYER:
	public override void OnStartLocalPlayer() {
		GetComponent<MeshRenderer>().material.color = Color.blue;
		playerNameTextObject.text = playerName;
	}// END ON START LOCAL PLAYER:

	
	//UPDATE:
    void Update() {
		if (!isLocalPlayer) {
			return;
		}

		cam.transform.position = this.transform.position - cameraOffsetVector;
		
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * ySpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			CmdFire();
		}
    } // END UPDATE


	// SET NAME:
	void SetName(){
		//if (!isServer) return;
		playerNameTextObject.text = playerName;
	} // END SET NAME

	
	// FIRE:
	[Command]
	void CmdFire() {
		// Play laser SFX
		laserSFX.Play();
		
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		
		// Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);
		
		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	} // END FIRE


	// ON GUI:
	void OnGUI(){
		if (!isLocalPlayer) return;

		playerName = GUI.TextField (new Rect(10, 10, 200, 21), playerName, 25);
		if (GUI.Button(new Rect(210, 10, 70, 21), "Set Name")) SetName();
	}
} // END CLASS