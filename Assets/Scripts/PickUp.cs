using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PickUp : MonoBehaviour
{

  [SerializeField]
    private Text pickUpText;

    private bool pickUpAllowed;

	// Use this for initialization
	private void Start () {
        pickUpText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	private void Update () {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickItUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickItUp()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryUI>().Items.Count > 0)
        {
            Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryUI>().Items.Any(x => x.name.Contains(gameObject.name)));
        }
        
        if(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryUI>().Items.Any(x => x.name.Contains(gameObject.name)))
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryUI>().Items.First(x => x.name.Contains(gameObject.name));
            obj.GetComponent<AbstractItem>().Amount += gameObject.GetComponent<AbstractItem>().Amount;
            GameObject.Destroy(gameObject);
        }
        else
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryUI>().AddItem(gameObject);

        //Destroy(gameObject);
    }

}
