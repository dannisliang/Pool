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
		if (rb.velocity.sqrMagnitude < 0.01) {
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}

	public void startMove(float mag){
		rb.AddForce (3*mag*camera.look);
	}
}
