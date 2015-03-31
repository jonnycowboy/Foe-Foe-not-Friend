using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {
	private GameObject planet;
	public Rigidbody rb;
	private Vector3 oldMouse;
	private Vector3 mouseSpeed;
	Vector3 offset;
	Vector3 screenPoint;

	void Start() {
		planet = GameObject.Find("ceres");
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		Vector3 gravityVector = planet.transform.position - transform.position;
		rb.AddForce(gravityVector, ForceMode.Acceleration);

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
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
	
	void OnMouseUp(){
		mouseSpeed = oldMouse - Input.mousePosition;
		//rb.AddForce(mouseSpeed.normalized * -1, ForceMode.Impulse);
		rb.velocity = mouseSpeed.normalized;
	}

	// Update is called once per frame
	void Update () {


	}
}
