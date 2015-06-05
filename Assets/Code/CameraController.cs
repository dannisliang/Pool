using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//private Vector3 ballDist;
	public GameObject ball;
	public float ang;
	public Vector3 look;	

	// Use this for initialization
	void Start () {
		//ballDist = new Vector3 (0, 3, -5);
		ang = 0;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKey (KeyCode.Z))
			ang += 2 * Time.deltaTime;
		else if (Input.GetKey (KeyCode.X))
			ang -= 2 * Time.deltaTime;
		Vector3 v = new Vector3 (5 * Mathf.Cos (ang), 3, 5 * Mathf.Sin (ang));
		look = -0.2f*v + new Vector3 (0, 0.6f, 0);
		transform.position = ball.transform.position + v;
		transform.LookAt (ball.transform.position);
	}
}
