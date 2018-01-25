using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float maxAmmo;
    public float curretAmmo;
    public Vector3 fire;
    public RaycastHit hit;
    public GameObject inpact;
    public WeaponManager manager;
    public int dmg;
    public bool reload;
    public float reloadTime;
    public bool mayFire = true;
    public float fireTime;
    public GameObject shot;
    public Text t;
    public Text mayShoot;
    
    // Use this for initialization
	void Start ()
    {
        maxAmmo = curretAmmo;
        manager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();
        reload = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mayFire == false)
        {
            fireTime -= Time.deltaTime;
            if (fireTime < 1)
            {
                mayFire = true;
                fireTime = 3;
            }
        }
        
        //reload
        if (curretAmmo < 1)
        {
            reload = true;
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
            {
                reload = false;
                reloadTime = 4;
                curretAmmo += 10;
            }
           
        }
        //Fire
        if(GameObject.FindWithTag("Manager").GetComponent<WeaponManager>().startButtonSwtitch.activeSelf == false)
        {
            mayShoot.text = "Fire:" + fireTime.ToString("F0");
            if (Input.GetButtonDown("Fire1"))
            {
                if (reload == false)
                {
                    if (mayFire == true)
                    {
                        curretAmmo -= 1;
                        t.text = "Ammo:" + curretAmmo.ToString();
                        GameObject fireWeapon = Instantiate(shot, Vector3.forward, Quaternion.identity);
                        manager.Delete(fireWeapon, 1);

                        mayFire = false;
                        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
                        {
                            if (hit.transform.tag == "Enemy")
                            {
                                GameObject g = Instantiate(inpact, hit.point, Quaternion.identity);
                                manager.Delete(g, 2);
                                hit.transform.gameObject.GetComponent<EnemyHealth>().Healt(dmg);

                            }
                        }

                    }

                }

            }
        }
        
        Debug.DrawRay(transform.position, transform.forward * 5, Color.cyan);
        GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();
        
    }
    
}
