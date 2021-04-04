using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> Items;
    [SerializeField]
    const int AMOUNT_OF_SLOTS = 20;

    [SerializeField]
    GameObject Handler;

    [SerializeField]
    List<GameObject> _Slots;

    public List<GameObject> Slots { get { return _Slots; } set { _Slots = value; SlotsUpdate(); } }


    void Start()
    {

        for (int i = 0; i < AMOUNT_OF_SLOTS; i++)
            Slots.Add(null);

        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i] = Handler.transform.GetChild(i).gameObject;
        }


    }

    void Update()
    {

    }

    void SlotsUpdate()
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i] = Handler.transform.GetChild(i).gameObject;
        }

    }

    public void AddItem(GameObject item)
    {

        GameObject PickedItem = item;
        //Items.Add(item);
        PickedItem.transform.SetParent(GameObject.FindGameObjectWithTag("ItemsFolder").transform);
        PickedItem.transform.position = transform.position;
        //PickedItem.SetActive(false);

        //SlotsUpdate();
        UpdateInventorySlots();

    }

    public void RemoveItem(int itemId)
    {

        if (Items[itemId] != null)
        {
            Items[itemId].transform.SetParent(null);
            Items[itemId].transform.position = transform.position;
            //Items[itemId].SetActive(true);
            GameObject itemSlot = Slots[itemId];

            //Items.RemoveAt(itemId);

        }
        //SlotsUpdate();
        UpdateInventorySlots();

    }

    void UpdateInventorySlots()
    {

        Items.Clear();


        Transform[] allitems = GameObject.FindGameObjectWithTag("ItemsFolder").GetComponentsInChildren<Transform>().Where(x => x.tag == "InventoryItem").ToArray();

        foreach (var item in allitems)
        {
            Items.Add(item.gameObject);
            Debug.Log("Added " + item.name);
        }

        ClearAllSlots();

        for (int i = 0; i < Items.Count; i++)
        {

            Slots[i].GetComponent<SlotInfo>().itemID = i;

            if (Items[i] != null)
            {

                Slots[i].GetComponent<SlotInfo>().itemText = Items[i].GetComponent<AbstractItem>().Description + "\nAmont:" + Items[i].GetComponent<AbstractItem>().Amount;
                Slots[i].GetComponent<Image>().sprite = Items[i].GetComponent<SpriteRenderer>().sprite;
                Slots[i].name = Items[i].name;

                Debug.Log("Slot Name: " + Slots[i].name + " Item: " + Items[i].name);
            }
        }
    }

    void ClearAllSlots()
    {
        for (int i = 0; i < AMOUNT_OF_SLOTS; i++)
        {
            Slots[i].GetComponent<SlotInfo>().itemText = "";
            Slots[i].GetComponent<Image>().sprite = null;
            Slots[i].name = "Empty";
            Slots[i].GetComponent<SlotInfo>().itemID = 0;
        }
    }

}
