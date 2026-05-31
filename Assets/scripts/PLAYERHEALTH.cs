using System;
using TMPro;
using UnityEngine;



public class PLAYERHEALTH : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] TMP_Text healthUI;
    [SerializeField] GameObject gameoverscreen;
    [SerializeField] GameObject backgroundUI;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hurtSound;
   
    void Update()
    {
        death();
        
    }

    private void death()
    {
        if (health <= 0)
        {
            gameoverscreen.SetActive(true);
             Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            backgroundUI.SetActive(false);
         
        }
    }

    public void takeplayerdamage(int damage)
    {
        audioSource.PlayOneShot(hurtSound);
         health-= damage;
        Debug.Log("health" + health);
        healthUI.text = health.ToString();
       
    }
}
   
