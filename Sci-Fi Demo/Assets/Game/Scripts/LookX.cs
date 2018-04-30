using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {

    [SerializeField]
    private float _mouseSensitivity = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 updatedAngles = transform.localEulerAngles;
        float mouseX = Input.GetAxis("Mouse X");
        updatedAngles.y += mouseX * _mouseSensitivity;
        transform.localEulerAngles = updatedAngles;
	}
}
