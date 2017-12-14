using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public RaycastHit hit2;
    public int dmg;
    public GameObject inpact;
    public Manager manager;
    public Vector3 hitAnimation;
    public Transform target;
    public float hitAngel;
    public GameObject weapon;
    public GameObject weapon2;

	// Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
        weapon.SetActive(true);
        weapon2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //hitanimation
            
            //hitAnimation = target.position - transform.position;
            //hitAngel = Vector3.Angle(hitAnimation, transform.forward);
            //transform.Translate(transform.forward * Time.deltaTime * 1);
            //transform.rotation = Quaternion.identity;
            
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
        Debug.DrawRay(transform.position, transform.forward * 5, Color.black);
        
        //WeaponSwitch
        if (Input.GetKeyDown("1"))
        {
            weapon.SetActive(true);
            weapon2.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            weapon.SetActive(false);
            weapon2.SetActive(true);
        }
    }
       
}
