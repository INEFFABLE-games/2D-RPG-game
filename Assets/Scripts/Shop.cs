using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField]
    GameObject text;

    [SerializeField]
    bool canOpen;

    void Open()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = true;
            text.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").transform.Find("Shop").transform.Find("ShopUI").gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Shop").GetComponent<ShopUI>().UpdateInventorySlots();
            other.GetComponent<AbstractCharacter>().CanShoot = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = false;
            text.SetActive(false);

            GameObject.FindGameObjectWithTag("Player").transform.Find("Shop").transform.Find("ShopUI").gameObject.SetActive(false);

            other.GetComponent<AbstractCharacter>().CanShoot = true;
        }
    }

    private void Update()
    {

    }

}
