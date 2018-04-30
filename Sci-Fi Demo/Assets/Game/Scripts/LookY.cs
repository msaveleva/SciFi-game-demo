using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {

    [SerializeField]
    private float _mouseSensitivity = 5.0f;
    [SerializeField]
    private bool _invertedCamera = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 updatedAngles = transform.localEulerAngles;
        float inversionMultiplier = _invertedCamera ? -1 : 1;
        float mouseY = Input.GetAxis("Mouse Y");
        updatedAngles.x += mouseY * _mouseSensitivity * inversionMultiplier;
        transform.localEulerAngles = updatedAngles;
	}
}
