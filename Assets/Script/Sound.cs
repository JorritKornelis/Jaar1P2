using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource shotSoundPlace;
    public AudioClip shotSound;
    // Use this for initialization
    void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindWithTag("MainCamera").GetComponent<Weapon>().enabled == true)
        {
            if (GameObject.FindWithTag("MainCamera").GetComponent<Weapon>().mayFire == true)
            {
                shotSoundPlace.clip = shotSound;
                shotSoundPlace.Play();
            }
        }
        else
        {

        }
	}
}
