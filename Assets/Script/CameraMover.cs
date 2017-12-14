using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public Vector3 cameraRotator;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

      cameraRotator.x =-Input.GetAxis("Mouse Y");
      transform.Rotate(cameraRotator);
	}
}
