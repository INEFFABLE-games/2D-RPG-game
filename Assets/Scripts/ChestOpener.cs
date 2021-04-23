using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{

    [SerializeField]
    List<GameObject> _items;

    [SerializeField]
    int _amountOfItems;

    [SerializeField]
    GameObject text;

    [SerializeField]
    bool canOpen;
    [SerializeField]
    GameObject destroyEffect;

    void Open()
    {
        Debug.Log(_items.Count);
        for (int i = 0; i < _amountOfItems; i++)
        {
            GameObject item = Instantiate(_items[Random.Range((int)0, (int)_items.Count)], transform.position + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)), transform.rotation);
            item.GetComponent<AbstractItem>().Amount = (uint)Random.Range(1,5);
        }
        Instantiate(destroyEffect,transform.position,transform.rotation);
        GameObject.Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = true;
                text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = false;
                text.SetActive(false);
        }
    }

    private void Update()
    {
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Open();
            }
        }
    }

}
