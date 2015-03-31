using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {
	private GameObject planet;
	public Rigidbody rb;
	private Vector3 oldMouse;
	private Vector3 oldMouse2;
	private Vector3 mouseDist;
	Vector3 offset;
	Vector3 screenPoint;
	bool flinged = false;
	bool dragging = false;

	void Start() {
		planet = GameObject.Find("ceres");
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		float td = 0;
		Vector3 gravityVector = planet.transform.position - transform.position;
		rb.AddForce(gravityVector, ForceMode.Acceleration);
		if (dragging){
			td = td + Time.fixedDeltaTime;
			mouseDist = oldMouse - Input.mousePosition;
		}
		if (flinged) {
			//rb.AddForce(Vector3.Scale(mouseDist.normalized, new Vector3(-1/td, -1/td, -1/td)), ForceMode.VelocityChange);
			rb.AddForce(Vector3.Scale(mouseDist, new Vector3(-1/(Time.fixedDeltaTime*100), -1/(Time.fixedDeltaTime*100), -1/(Time.fixedDeltaTime*100))), ForceMode.VelocityChange);
			flinged = false;
			td = 0;
			dragging = false;
		}

	}

	void OnMouseDown ()
	{
		oldMouse = Input.mousePosition;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		//rb.AddForce(-transform.forward * 500f);
		//rb.useGravity = true;
	}

	void OnMouseDrag()
	{
		dragging = true;
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
		oldMouse = Input.mousePosition;
	}
	
	void OnMouseUp(){

		//mouseDist = oldMouse - Input.mousePosition;
		flinged = true;
		//rb.AddForce(mouseSpeed.normalized * -1, ForceMode.VelocityChange);
		//rb.velocity = mouseSpeed.normalized;
	}

	// Update is called once per frame
	void Update () {


	}
}
