using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> Items;
    [SerializeField]
    const int AMOUNT_OF_SLOTS = 5;

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
        Items.Add(item);
        PickedItem.transform.SetParent(GameObject.FindGameObjectWithTag("ItemsFolder").transform);
        PickedItem.SetActive(false);

        //SlotsUpdate();
        UpdateInventorySlots();

    }

    public void RemoveItem(int itemId)
    {

        if (Items[itemId] != null && Slots[itemId].name != "Empty")
        {
            Items[itemId].transform.SetParent(null);
            Items[itemId].SetActive(true);
            GameObject itemSlot = Slots[itemId];
            itemSlot.name = "Empty";
            Items.RemoveAt(itemId);
        }


        //SlotsUpdate();
        UpdateInventorySlots();

    }

    void UpdateInventorySlots()
    {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] != null)
                {
                    Debug.Log(Slots[i].name);
                    Debug.Log(Items[i].name);

                    Slots[i].GetComponent<SlotInfo>().itemText = Items[i].GetComponent<AbstractItem>().Description;
                    Slots[i].GetComponent<SlotInfo>().itemID = i;
                    Slots[i].GetComponent<Image>().sprite = Items[i].GetComponent<SpriteRenderer>().sprite;
                    Slots[i].name = Items[i].name;
                    
                }
            }
    }

}
