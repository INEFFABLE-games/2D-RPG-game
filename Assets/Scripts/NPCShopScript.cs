using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShopScript : MonoBehaviour
{

    bool canOpen;

    void Start()
    {
       canOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {  
        if(other.transform.tag == "Player")
        {
            canOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            canOpen = false;
        }
    }

    private void Update() 
    {
        if(canOpen)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //GameObject.FindGameObjectsWithTag("Inventory")
                Debug.Log("Test!");
            }
        }    
    }


}
