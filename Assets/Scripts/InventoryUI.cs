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
    GameObject coins;

    [SerializeField]
    GameObject Handler;

    [SerializeField]
    GameObject EquippedHandler;

    //----------------------------------------------------EQUIP ITEMS---------------------------------

    public List<GameObject> equippedItems;
    public List<GameObject> equippedSlots;
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
        equippedSlots = equippedSlots.Select((x, i) => x = EquippedHandler.transform.GetChild(i).gameObject).ToList();


        UpdateInventorySlots();
        UpdateEquipSlots();

    }

    void Update()
    {

    }

    void SlotsUpdate()
    {
        UpdateInventorySlots();
        UpdateEquipSlots();
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

        UpdateInventorySlots();
        UpdateEquipSlots();
        //UpdateInventorySlots();

    }

    public void DropAllItems()
    {
        Transform[] allitems = GameObject.FindGameObjectWithTag("ItemsFolder").GetComponentsInChildren<Transform>().Where(x => x.tag == "InventoryItem").ToArray();
        foreach (var item in allitems)
        {
            item.SetParent(null);
            item.position = transform.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 0);
        }

        UpdateInventorySlots();
        UpdateEquipSlots();

    }

    // public void RemoveSomeCoins(string itemName,uint Amount)
    // {

    //     if (Items.Any(x => x.name.Contains(itemName)) && x.GetComponent<AbstractItem>().itemType != "Equipttable")
    //     {
    //         itemId.transform.SetParent(null);
    //         itemId.transform.position = transform.position + new Vector3(Random.Range(-1.5f,1.5f),Random.Range(-1.5f,1.5f),0);

    //         //Items.RemoveAt(itemId);

    //     }
    //     SlotsUpdate();
    //     //UpdateInventorySlots();

    // }

    public void RemoveItem(GameObject itemId)
    {

        if (itemId != null)
        {
            itemId.transform.SetParent(null);
            itemId.transform.position = transform.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 0);

            //Items.RemoveAt(itemId);

        }
        UpdateInventorySlots();
        UpdateEquipSlots();
        //UpdateInventorySlots();

    }

    public void SellItems(GameObject item, int amount)
    {
        if (item != null && item.name != "Coins")
        {
            if (item.GetComponent<AbstractItem>()._Amount > amount)
            {
                Debug.Log("Selled (" + item.name + "): " + amount);
                item.GetComponent<AbstractItem>()._Amount -= (uint)amount;

                GameObject newcoins = Instantiate(coins);
                newcoins.name = "Coins";
                newcoins.GetComponent<AbstractItem>()._Amount = (uint)amount * newcoins.GetComponent<AbstractItem>().Cost;

                AddItem(newcoins);

            }
            else if (item.GetComponent<AbstractItem>()._Amount <= amount)
            {
                Debug.Log("Selled All");

                GameObject newcoins = Instantiate(coins);
                newcoins.name = "Coins";
                newcoins.GetComponent<AbstractItem>()._Amount = (uint)amount * newcoins.GetComponent<AbstractItem>().Cost;

                AddItem(newcoins);

                GameObject.Destroy(item);

            }

        }

        UpdateInventorySlots();
        UpdateEquipSlots();

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

    public void EquipItem(GameObject itemId)
    {
        if (itemId != null && itemId.GetComponent<AbstractItem>().itemType == "Equipttable")
        {
            AbstractItem itemscpt = itemId.GetComponent<AbstractItem>();

            if (!itemscpt.equipped && equippedSlots.Any(x => x.GetComponent<SlotInfo>().item == null))
            {

                if (itemId.GetComponent<AbstractItem>()._armorType == (int)AbstractItem.armorType.Head)
                {
                    itemId.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0.65f, 0);
                }
                else if (itemId.GetComponent<AbstractItem>()._armorType == (int)AbstractItem.armorType.Body)
                {
                    itemId.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0, 0);
                }


                itemscpt.equipped = true;
                itemscpt.EnableItemEffect();
                itemId.transform.SetParent(GameObject.FindGameObjectWithTag("EquippedItems").gameObject.transform);

                //Debug.Log("EQUIPPED: " + itemId.name);

            }
            else if (itemscpt.equipped)
            {
                itemId.transform.position = GameObject.FindGameObjectWithTag("ItemsFolder").transform.position;
                itemscpt.equipped = false;
                itemscpt.DisableItemEffect();
                itemId.transform.SetParent(GameObject.FindGameObjectWithTag("ItemsFolder").gameObject.transform);

                //Debug.Log("UNEQUIPPED: " + itemId.name);
            }

            //Items.RemoveAt(itemId);

        }

        SlotsUpdate();
    }

    void UpdateEquipSlots()
    {

        equippedItems.Clear();

        Transform[] allitems = GameObject.FindGameObjectWithTag("EquippedItems").GetComponentsInChildren<Transform>().Where(x => x.tag == "InventoryItem").ToArray();

        foreach (var item in allitems)
        {
            equippedItems.Add(item.gameObject);
        }

        ClearEquipSlots();

        for (int i = 0; i < equippedItems.Count; i++)
        {

            equippedSlots[i].GetComponent<SlotInfo>().itemID = i;

            if (equippedItems[i] != null)
            {

                equippedSlots[i].GetComponent<SlotInfo>().itemText = equippedItems[i].GetComponent<AbstractItem>().Description + "\nAmont:" + equippedItems[i].GetComponent<AbstractItem>().Amount;
                equippedSlots[i].GetComponent<SlotInfo>().itemName = equippedItems[i].name;
                equippedSlots[i].GetComponent<SlotInfo>().itemImage = equippedItems[i].GetComponent<SpriteRenderer>().sprite;
                equippedSlots[i].GetComponent<SlotInfo>().item = equippedItems[i].gameObject;
                equippedSlots[i].GetComponent<Image>().sprite = equippedItems[i].GetComponent<SpriteRenderer>().sprite;
                equippedSlots[i].name = Items[i].name;

                //Debug.Log("Slot Name: " + Slots[i].name + " Item: " + Items[i].name);
            }
        }



    }

    void ClearEquipSlots()
    {
        for (int i = 0; i < 4; i++)
        {
            equippedSlots[i].GetComponent<SlotInfo>().itemText = "";
            equippedSlots[i].GetComponent<SlotInfo>().itemName = "";
            equippedSlots[i].GetComponent<SlotInfo>().itemImage = null;
            equippedSlots[i].GetComponent<SlotInfo>().item = null;
            equippedSlots[i].GetComponent<Image>().sprite = null;
            equippedSlots[i].name = "Empty";
            equippedSlots[i].GetComponent<SlotInfo>().itemID = 0;
        }
    }
}
