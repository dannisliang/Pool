using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//private Vector3 ballDist;
	public GameObject ball;
	public float ang;
	public Vector3 look;	

	private bool topView;

	// Use this for initialization
	void Start () {
		ang = 0;
		topView = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//Cambio del angulo de la camara
		if (Input.GetKeyDown (KeyCode.T))
			topView = !topView;

		//Rotacion de la camara
		float vx = Input.GetAxisRaw("Horizontal");
		if(vx>0)
			ang += 2 * Time.deltaTime;
		else if (vx<0)
			ang -= 2 * Time.deltaTime;

		//Obtencion del vector look (apunta a la bola blanca)
		Vector3 v = new Vector3 (5 * Mathf.Cos (ang), 3, 5 * Mathf.Sin (ang));
		look = -0.2f*v + new Vector3 (0, 0.6f, 0);

		//Posicion y rotacion de la camara
		if (topView) {
			transform.position = transform.position*0.85f + 0.15f*new Vector3(0,20,0);
			transform.eulerAngles = transform.eulerAngles*0.85f + 0.15f*new Vector3(90,0,0);
		}
		else {
			transform.position = transform.position*0.85f + 0.15f*(ball.transform.position + v);
			transform.LookAt (ball.transform.position);
		}

	}

	//Dibujar textos y barras
	void onGUI(){

	}
}
