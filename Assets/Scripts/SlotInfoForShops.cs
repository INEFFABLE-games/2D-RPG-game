using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotInfoForShops : MonoBehaviour
{
    public string _itemText;
    public string _itemName;
    public Sprite _itemImage;

    public int itemID;
    public string itemText { get { return _itemText; } set { _itemText = value; } }
    public string itemName { get { return _itemName; } set { _itemName = value; } }
    public Sprite itemImage { get { return _itemImage; } set { _itemImage = value; } }
    public Button sellButton;

    [SerializeField]
    int AmountOfItems = 1;
    [SerializeField]
    GameObject coinsForSale;

    public GameObject item;

    public GameObject textBox;
    public GameObject NameBox;
    public GameObject ImageBox;
    public void InfoUpdateTextPlease()
    {

        textBox.GetComponent<Text>().text = _itemText;

        if (item.GetComponent<AbstractItem>().itemType == "Equipttable")
        {
            if (item.name.Contains("Hat"))
            {
                Hat stats = item.GetComponent<Hat>();
                textBox.GetComponent<Text>().text = _itemText +
                "\nArmor: " + stats.multiArmor +
                "\nMagic Power: " + stats.multiMagicDamage +
                "\nSpeed: " + stats.multiSpeed +
                "\nWeapon Damage: " + stats.multiWeaponDamage;
            }
            else if(item.name.Contains("Ring"))
            {
                Magic_Ring stats = item.GetComponent<Magic_Ring>();
                textBox.GetComponent<Text>().text = _itemText +
                "\nArmor: " + stats.multiArmor +
                "\nMagic Power: " + stats.multiMagicDamage +
                "\nSpeed: " + stats.multiSpeed +
                "\nWeapon Damage: " + stats.multiWeaponDamage;
            }
            else if(item.name.Contains("Essence"))
            {
                Essence stats = item.GetComponent<Essence>();
                textBox.GetComponent<Text>().text = _itemText +
                "\nArmor: " + stats.multiArmor +
                "\nMagic Power: " + stats.multiMagicDamage +
                "\nSpeed: " + stats.multiSpeed +
                "\nWeapon Damage: " + stats.multiWeaponDamage;
            }


        }
        NameBox.GetComponent<Text>().text = _itemName;
        ImageBox.GetComponent<Image>().sprite = itemImage;

        //UnityEditor.Events.UnityEventTools.AddPersistentListener(dropButton.onClick,act);

        sellButton.onClick.RemoveAllListeners();
        sellButton.onClick.AddListener(SellItem);
    }

    void SellItem()
    {
        Debug.Log("REAFGAEGAUOEGHUO{AEGUAEGAEOAEG");
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryUI>().RemoveItem(item);
        coinsForSale.GetComponent<AbstractItem>().Amount = (uint)(AmountOfItems * item.GetComponent<AbstractItem>().Cost);
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryUI>().AddItem(coinsForSale);
    }

    private void Start() 
    {
        coinsForSale = GameObject.FindGameObjectWithTag("ItemsFolder").transform.Find("Coins").gameObject;
    }

}
