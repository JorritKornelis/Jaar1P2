using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float maxAmmo;
    public float curretAmmo;
    public Vector3 fire;
    public RaycastHit hit;
    public GameObject inpact;
    public Manager manager;
    public int dmg;
    public GameObject weapon;
    public GameObject weapon2;
    public bool reload;
    public float reloadTime;
	
    // Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
        maxAmmo = 10;
        maxAmmo = curretAmmo;
        weapon.SetActive(true);
        weapon2.SetActive(false);
        reload = false;
    }

    // Update is called once per frame
    void Update()
    {
        //reaload
        if (curretAmmo < 1)
        {
            reload = true;
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
            {
                reload = false;
                reloadTime = 0;
                curretAmmo += 10;
            }
           
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (reload == false)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        GameObject g = Instantiate(inpact, hit.point, Quaternion.identity);
                        manager.Delete(g, 1);
                        hit.transform.gameObject.GetComponent<EnemyHealth>().Healt(dmg);

                    }
                }
                curretAmmo -= 1;
            }
            
        }
        Debug.DrawRay(transform.position, transform.forward * 10, Color.cyan);

        //WeaponSwitch
        if (Input.GetKeyDown("1"))
        {
            weapon.SetActive (true);
            weapon2.SetActive (false);
        }
        if (Input.GetKeyDown("2"))
        {
            weapon.SetActive(false);
            weapon2.SetActive(true);    
        }
    }
    
}
