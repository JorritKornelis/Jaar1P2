using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 move;
    public Vector3 cameraRotate;
    public float moveSpeed;
   
	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        cameraRotate.y =Input.GetAxis("Mouse X");
        transform.Rotate(cameraRotate);

        float x =Input.GetAxis("Horizontal");
        float z =Input.GetAxis("Vertical");
        move.x = x;
        move.z = z;
        transform.Translate(move * moveSpeed * Time.deltaTime);


    }
       
}
