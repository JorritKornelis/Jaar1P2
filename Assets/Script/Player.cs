using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector3 move;
    public Vector3 cameraRotate;
    public float moveSpeed;
    public int playerHealth;
    public int playerMaxhealth;
    public Text health;
    public GameObject end1;
    public GameObject end2;
    public GameObject victorySwitch;
    public GameObject gameoverSwitch;
    public Button restartButton;
    public GameObject restartSwitch;

	// Use this for initialization
	void Start ()
    {
        restartButton.onClick.AddListener(RestartButton);
        victorySwitch.SetActive(false);
        gameoverSwitch.SetActive(false);
        restartSwitch.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        cameraRotate.y =Input.GetAxis("Mouse X");
        transform.Rotate(cameraRotate);
       
        float x =Input.GetAxis("Horizontal");
        float z =Input.GetAxis("Vertical");
        move.x = x;
        move.z = z;
        transform.Translate(move * moveSpeed * Time.deltaTime);

        health.text = "Health:" + playerHealth.ToString();
        if (playerHealth < 1)
        {
            print("Gameover");
            gameoverSwitch.SetActive(true);
            gameObject.GetComponent<Player>().enabled = false;
            restartSwitch.SetActive(true);
        }
        
        //Victory
        if (transform.position.z > end1.transform.position.z)
        {
            if (transform.position.z < end2.transform.position.z)
            {
                if (transform.position.x < end1.transform.position.x)
                {
                    if (transform.position.x < end2.transform.position.x)
                    {
                        print("Victory");
                        victorySwitch.SetActive(true);
                        restartSwitch.SetActive(true);
                        gameObject.GetComponent<Player>().enabled = false;
                        
                    }
                }
            }
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Project 2.1");
        restartSwitch.SetActive(false);
        
    }
}
