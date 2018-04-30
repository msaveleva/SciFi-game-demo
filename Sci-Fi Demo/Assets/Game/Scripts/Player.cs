using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float kGravity = 9.81f;


	[SerializeField]
	private float speed = 3.5f;

	private CharacterController _charaController;

	// Use this for initialization
	void Start () {
		_charaController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
		Vector3 direction = new Vector3 (horizontalInput, 0, verticalInput);
		Vector3 velocity = direction * speed;
		velocity.y -= kGravity;

        //transform to global coordinates.
        velocity = transform.transform.TransformDirection(velocity);

		_charaController.Move (velocity * Time.deltaTime);
	}
}
