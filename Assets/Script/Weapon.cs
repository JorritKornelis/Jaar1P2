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
    public Text mayReload;
    public GameObject reloadSwitch;
    
    // Use this for initialization
	void Start ()
    {
        maxAmmo = curretAmmo;
        manager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();
        reload = false;
        reloadSwitch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mayFire == false)
        {
            fireTime += Time.deltaTime;
            if (fireTime > 2)
            {
                mayFire = true;
                fireTime = 0;
            }
        }
        
        //reload
        if (curretAmmo < 1)
        {
            reload = true;
            reloadTime -= Time.deltaTime;
            mayReload.text = "Reload:" + reloadTime.ToString();
            reloadSwitch.SetActive(true);

            if (reloadTime <= 4)
            {
                reloadTime = 4;
                curretAmmo += 10;
                mayReload.text = "Reload:" + reloadTime.ToString();
                reload = false;
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
                        GameObject fireWeapon = Instantiate(shot, transform.position, Quaternion.identity);
                        manager.Delete(fireWeapon, 1);
                        mayFire = false;
                        reloadSwitch.SetActive(false);

                        if (Physics.Raycast(transform.position, transform.forward, out hit, 15))
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
        /*if (GameObject.FindWithTag("Player").GetComponent<Player>().restart == true)
        {
            print("ReReload");
            curretAmmo = maxAmmo;
        }*/
    }
    
}
