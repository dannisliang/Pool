using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public Ball mainBall;
	public Palo palo;

	private GameObject[] balls;
	private float maxv;
	private int totalPlayers = 2;

	// Use this for initialization
	void Start () {
		balls = GameObject.FindGameObjectsWithTag ("Balls");
	}
	
	// Update is called once per frame
	void Update () {
		//Obtiene la velocidad maxima de todas las bolas
		maxv = mainBall.rb.velocity.sqrMagnitude;
		foreach (GameObject gobj in balls) {
			BallPrefab bp = gobj.GetComponent<BallPrefab>();
			if(maxv < bp.rb.velocity.sqrMagnitude)
				maxv = bp.rb.velocity.sqrMagnitude;
		}
		palo.canPlay = (maxv<0.01);
	}

}
