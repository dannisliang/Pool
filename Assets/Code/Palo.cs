using UnityEngine;
using System.Collections;

public class Palo : MonoBehaviour {

	public Ball ball;
	public CameraController camera;

	private Rigidbody rb;
	private int v;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		v = 0;
		//rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			v = 1;
		}
		if (v != 0) {
			transform.position = transform.position + 10 * v * Time.deltaTime * camera.look;
		} else {
			transform.localPosition = ball.transform.position - camera.look * 10;
		}
		transform.eulerAngles = new Vector3(90, 0, camera.ang*180/Mathf.PI+90);
	}

	void OnCollisionEnter(Collision collision) {
		v = -1;
		ball.startMove ();
		Invoke ("stop", 1);
	}

	void stop(){
		v = 0;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		//rb.freezeRotation = true;
	}
}
