﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon2 : MonoBehaviour
{
    public RaycastHit hit2;
    public int dmg;
    public GameObject inpact;
    public GameObject chargeInpact;
    public WeaponManager manager;
    public float chargeTime;
    public float maxCharge;
    public Text charge;

	// Use this for initialization
	void Start ()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            //hitanimation
            
            
            if (Physics.Raycast(transform.position, transform.forward, out hit2, 100))
            {
                if (hit2.transform.tag == "Enemy")
                {
                    GameObject g = Instantiate(inpact, hit2.point, Quaternion.identity);
                    manager.Delete(g, 2);
                    hit2.transform.gameObject.GetComponent<EnemyHealth>().Healt(dmg);
                }
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 1, Color.green);
        GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();

        if (Input.GetButton("Fire2"))
        {
            print("1");
            chargeTime += Time.deltaTime;
            if (chargeTime > maxCharge)
            {
                chargeTime = maxCharge;
            }
            charge.text = "Charge:" + chargeTime.ToString("F0");
        }
        if (Input.GetButtonUp("Fire2") && chargeTime <= maxCharge)
        {
            chargeTime = 0;
            print("2");
            if(hit2.transform.tag == "Enemy")
            {
                print("Hit2");
                hit2.transform.gameObject.GetComponent<EnemyHealth>().Healt(dmg + 2);
                GameObject g2 = Instantiate(chargeInpact, hit2.point, Quaternion.identity);
                manager.Delete(g2, 2);
            }
            charge.text = "Charge:" + chargeTime.ToString("F0");
        }
    }
       
}
