using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float moveSpeed;
	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == ("Player"))
        {
            print("hoi");
            hit.gameObject.GetComponent<Player>().playerHealth -= 1;
            
        }
    }
}
