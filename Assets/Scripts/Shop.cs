using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField]
    GameObject text;

    [SerializeField]
    bool canOpen;

    [SerializeField]
    GameObject ShopUI;


    void Open()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = true;
            text.SetActive(true);
            ShopUI.SetActive(true);
            GameObject.FindGameObjectWithTag("Shop").GetComponent<ShopUI>().UpdateInventorySlots();
            GameObject.FindGameObjectWithTag("Player").GetComponent<AbstractCharacter>().CanShoot = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = false;
            text.SetActive(false);

            ShopUI.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AbstractCharacter>().CanShoot = true;
        }
    }

    private void Update()
    {

    }

}
