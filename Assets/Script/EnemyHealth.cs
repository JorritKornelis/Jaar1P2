using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealt;
    
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
            Destroy(gameObject);
        }
	}
    public void Healt(float dmg)
    {
        enemyHealt -= dmg;
    }
   
}
