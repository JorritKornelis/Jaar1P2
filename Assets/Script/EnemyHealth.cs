using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealt;
    
	// Use this for initialization
	void Start ()
    {
      
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject obj = transform.gameObject;
		if (enemyHealt <= 0)
        {
            //transform.gameObject.GetComponent<Manager>().Delete(obj, 2);
            Destroy(gameObject);
        }
	}
    public void Healt(int dmg)
    {
        enemyHealt -= dmg;
    }
   
}
