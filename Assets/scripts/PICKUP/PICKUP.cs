using System;
using UnityEngine;

public abstract class PICKUP : MonoBehaviour
{
    private bool playerInRange = false;
    const string PLAYER_TAG = "player";
    [SerializeField] float rotationspeed = 100f;
    [SerializeField] GameObject pickupUI;
   
   
void Start()
{
    pickupUI.SetActive(false);
}
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
    {   
    activeweapon activeWeapon =GameObject.FindGameObjectWithTag(PLAYER_TAG).GetComponentInChildren<activeweapon>();
    onpickup(activeWeapon);
    pickupUI.SetActive(false);

    Destroy(gameObject);
    }
        
    
        transform.Rotate(0f, rotationspeed * Time.deltaTime, 0f);
    }
void OnTriggerEnter(Collider other)
    {
    if (other.gameObject.CompareTag(PLAYER_TAG))
    {
        pickupUI.SetActive(true);
        playerInRange = true;
    }
}


void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag(PLAYER_TAG))
    {
         playerInRange = false;
        pickupUI.SetActive(false);
    }
}
    protected abstract void onpickup(activeweapon activeweapon);
   
}
