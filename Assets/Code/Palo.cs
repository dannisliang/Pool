using UnityEngine;
using System.Collections;

public class Palo : MonoBehaviour {
	
	public Ball ball;
	public CameraController camera;
	public bool canPlay;
	
	private int v;
	private bool isHitting, isResting;
	private Vector3 mouseInit;
	private float mag;


	// Use this for initialization
	void Start () {
		v = 0;
		canPlay = true;
		isHitting = false;
		mag = 0;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//Si el palo esta descansando
		if (isResting) {
			if(Input.GetKeyDown(KeyCode.Space))
				isResting=false;
			return;
		}

		//Deteccion del mouse y calculo de la magnitud
		if (Input.GetButtonDown ("Fire1") && canPlay) {
			mouseInit = Input.mousePosition;
			mag = 0;
			isHitting = true;
		}
		else if (Input.GetButtonUp ("Fire1") && canPlay) {
			isHitting = false;
			v = 1;
		}
		if(isHitting)
			mag = (Input.mousePosition - mouseInit).magnitude;

		//Se establece la posicion del palo segun v
		if (v != 0) {
			transform.position = transform.position + 10 * v * Time.deltaTime * camera.look;
		} 
		else {
			transform.localPosition = ball.transform.position - camera.look * (8+mag/200);
		}

		//Rotacion del palo en el sentido de la camara
		transform.eulerAngles = new Vector3(90, 0, camera.ang*180/Mathf.PI+90);
	}

	void OnCollisionEnter(Collision collision) {
		//Si colisiona con la pelota blanca
		if (collision.gameObject.tag.Equals ("MainBall")) {
			ball.startMove (mag);
			mag = 0;
			restPosition();
		}
	}

	void stop(){
		v = 0;
	}

	//Deja el palo fuera del area de juego
	void restPosition(){
		transform.position = new Vector3 (0, 0, -20);
		transform.eulerAngles = Vector3.zero;
		isResting = true;
		stop ();
	}

}
