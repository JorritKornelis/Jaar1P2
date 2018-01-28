using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyHolder;
    public int numberOfEnemy;
	// Use this for initialization
	void Start ()
    {
        GameObject enemy =Instantiate(enemyHolder, transform.localPosition, Quaternion.identity);
        for(int i = 0;i < numberOfEnemy; i++)
        {
            Instantiate(enemy);
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
