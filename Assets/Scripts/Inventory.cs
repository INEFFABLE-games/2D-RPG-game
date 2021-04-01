using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<GameObject> Items;

    void Start()
    {
        Items = new List<GameObject>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.N))
        {
            DropItem(0);
        }

    }

    public void AddItem(GameObject item)
    {
        GameObject PickedItem = item;
        Items.Add(PickedItem);
        PickedItem.transform.SetParent(transform.GetChild(0));
        PickedItem.SetActive(false);
    }

    public void DropItem(int itemId)
    {
        if (Items[itemId] != null)
        {
            Items[itemId].transform.SetParent(null);
            Items[itemId].SetActive(true);
            Items.RemoveAt(itemId);
        }
    }

}
