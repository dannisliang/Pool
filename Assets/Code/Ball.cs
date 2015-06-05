using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Rigidbody rb;
	public CameraController camera;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void startMove(){
		rb.AddForce (500*camera.look);
	}
}
