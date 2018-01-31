using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon;
    public GameObject weapon2;
    public Button startButton;
    public Button quitButton;
    public GameObject startButtonSwtitch;
    public GameObject quitButtonSwitch;
    public Image crossHair;
    public GameObject crossHairSwitch;
	
    // Use this for initialization
	void Start ()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;

        weapon.SetActive(true);
        weapon2.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<Weapon>().enabled = false;
        GameObject.FindWithTag("MainCamera").GetComponent<Weapon2>().enabled = false;

        startButton.onClick.AddListener(StartButton);
        quitButton.onClick.AddListener(QuitButton);
        crossHairSwitch.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //WeaponSwitch
        if (Input.GetKeyDown("1"))
        {
            weapon.SetActive(true);
            weapon2.SetActive(false);
            GameObject.FindWithTag("MainCamera").GetComponent<Weapon>().enabled = true;
            GameObject.FindWithTag("MainCamera").GetComponent<Weapon2>().enabled = false;
        }
        if (Input.GetKeyDown("2"))
        {
            weapon.SetActive(false);
            weapon2.SetActive(true);
            GameObject.FindWithTag("MainCamera").GetComponent<Weapon>().enabled = false;
            GameObject.FindWithTag("MainCamera").GetComponent<Weapon2>().enabled = true;
        }

        if (startButtonSwtitch.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            crossHairSwitch.SetActive(true);
            quitButtonSwitch.SetActive(false);
        }
    }
    public void Delete(GameObject destroy, float time)
    {
        Destroy(destroy, time);
    }

    public void StartButton()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<Weapon>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
        startButtonSwtitch.SetActive(false);
        print("start werkt");
    }
    public void QuitButton()
    {
        print("Player has Quit");
        Application.Quit();
    }
    
}
