using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public List<GameObject> Items;
    [SerializeField]
    const int AMOUNT_OF_SLOTS = 20;

    [SerializeField]
    GameObject Handler;

    [SerializeField]
    GameObject coins;


    //----------------------------------------------------EQUIP ITEMS---------------------------------

    //public List<GameObject> equippedSlots{get{return _equippedSlots;}set{_equippedSlots = value;SlotsUpdate();}}



    //----------------------------------------------------END EQUIP ITEMS---------------------------------


    [SerializeField]
    List<GameObject> _Slots;

    public List<GameObject> Slots { get { return _Slots; } set { _Slots = value; SlotsUpdate(); } }


    void Start()
    {

        for (int i = 0; i < AMOUNT_OF_SLOTS; i++)
        {
            Slots.Add(null);
        }

        // for (int i = 0; i < 4; i++)
        // {
        //     equippedSlots.Add(null);
        // }

        // for (int i = 0; i < Slots.Count; i++)
        // {
        //     Slots[i] = Handler.transform.GetChild(i).gameObject;
        // }

        // for (int i = 0; i < equippedSlots.Count; i++)
        // {
        //     Slots[i] = Handler.transform.GetChild(i).gameObject;
        // }

        Slots = Slots.Select((x, i) => x = Handler.transform.GetChild(i).gameObject).ToList();

        UpdateInventorySlots();

    }

    void Update()
    {

    }

    void SlotsUpdate()
    {
        UpdateInventorySlots();
    }

    public void AddItem(GameObject item)
    {

        if (Items.Any(x => x.name.Contains(item.name)) && item.GetComponent<AbstractItem>().itemType != "Equipttable")
        {
            GameObject obj = Items.First(x => x.name.Contains(item.name));
            obj.GetComponent<AbstractItem>().Amount += item.GetComponent<AbstractItem>().Amount;
            GameObject.Destroy(item);
        }
        else
        {
            //Debug.Log("Dont Contains");
            GameObject PickedItem = item;
            //Items.Add(item);
            PickedItem.transform.SetParent(GameObject.FindGameObjectWithTag("ItemsFolder").transform);
            PickedItem.transform.position = GameObject.FindGameObjectWithTag("ItemsFolder").transform.position;
            //PickedItem.SetActive(false);
        }

        //SlotsUpdate();
        UpdateInventorySlots();

    }

    public void RemoveItem(GameObject itemId)
    {

        if (itemId != null)
        {
            itemId.transform.SetParent(null);
            itemId.transform.position = transform.position;
            //Items[itemId].SetActive(true);

            //Items.RemoveAt(itemId);

        }
        //SlotsUpdate();
        UpdateInventorySlots();

    }

    public void SellItem(GameObject item,int amount)
    {
        if(item.GetComponent<AbstractItem>()._Amount > amount)
        {
            item.GetComponent<AbstractItem>()._Amount -= (uint)amount;
            uint price = (uint)item.GetComponent<AbstractItem>().Amount * (uint)item.GetComponent<AbstractItem>().Cost;
            
            GameObject newcoins = Instantiate(coins);
            newcoins.GetComponent<AbstractItem>()._Amount = (uint)price;
            newcoins.transform.SetParent(GameObject.FindGameObjectWithTag("ItemsFolder").transform);

            AddItem(coins);
        }
    }

    void UpdateInventorySlots()
    {

        Items.Clear();

        Transform[] allitems = GameObject.FindGameObjectWithTag("ItemsFolder").GetComponentsInChildren<Transform>().Where(x => x.tag == "InventoryItem").ToArray();

        foreach (var item in allitems)
        {
            Items.Add(item.gameObject);
        }

        ClearAllSlots();

        for (int i = 0; i < Items.Count; i++)
        {

            Slots[i].GetComponent<SlotInfo>().itemID = i;

            if (Items[i] != null)
            {

                Slots[i].GetComponent<SlotInfo>().itemText = Items[i].GetComponent<AbstractItem>().Description + "\nAmont:" + Items[i].GetComponent<AbstractItem>().Amount;
                Slots[i].GetComponent<SlotInfo>().itemName = Items[i].name;
                Slots[i].GetComponent<SlotInfo>().itemImage = Items[i].GetComponent<SpriteRenderer>().sprite;
                Slots[i].GetComponent<SlotInfo>().item = Items[i].gameObject;
                Slots[i].GetComponent<Image>().sprite = Items[i].GetComponent<SpriteRenderer>().sprite;
                Slots[i].name = Items[i].name;

                //Debug.Log("Slot Name: " + Slots[i].name + " Item: " + Items[i].name);
            }
        }
    }

    void ClearAllSlots()
    {

        for (int i = 0; i < AMOUNT_OF_SLOTS; i++)
        {
            Slots[i].GetComponent<SlotInfo>().itemText = "";
            Slots[i].GetComponent<SlotInfo>().itemName = "";
            Slots[i].GetComponent<SlotInfo>().itemImage = null;
            Slots[i].GetComponent<SlotInfo>().item = null;
            Slots[i].GetComponent<Image>().sprite = null;
            Slots[i].name = "Empty";
            Slots[i].GetComponent<SlotInfo>().itemID = 0;
        }
    }
    }
    
