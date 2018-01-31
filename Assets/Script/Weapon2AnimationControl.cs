using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2AnimationControl : MonoBehaviour
{
    public Animator anim;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindWithTag("MainCamera").GetComponent<Weapon2>().enabled == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.Play("Weapon2Animation");
                print("Play");
            }
        }
            
    }
}
