using UnityEngine;
using System.Collections;

public class BallPrefab : MonoBehaviour {

	public Rigidbody rb;

	private GameObject palo;
	private Vector3 initPos;

	// Use this for initialization
	void Start () {
		initPos = transform.position;
		rb = GetComponent<Rigidbody> ();
		//Se ignoran los choques con el palo
		palo = GameObject.FindGameObjectsWithTag ("Palo")[0];
		Physics.IgnoreCollision (GetComponent<Collider> (), palo.GetComponent<Collider> ());
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -2) {
			transform.position = initPos;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
		if (rb.velocity.sqrMagnitude < 0.01) {
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}
}
