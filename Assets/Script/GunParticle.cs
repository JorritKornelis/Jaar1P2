using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParticle : MonoBehaviour
{
    public GameObject shot;
    public WeaponManager manager;
    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindWithTag("MainCamera").GetComponent<Weapon>().enabled == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(GameObject.FindWithTag("MainCamera").GetComponent<Weapon>().mayFire == true)
                {
                    GameObject fireWeapon = Instantiate(shot, transform.position, transform.rotation);
                    manager.Delete(fireWeapon, 1);
                }
            }
        }
    }
}
