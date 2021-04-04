using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotInfo : MonoBehaviour
{
    public string _itemText;
    public int itemID;
    public string itemText { get { return _itemText; } set { _itemText = value;} }
    public Button dropButton;

    UnityAction act;

    public GameObject textBox;

    public void InfoUpdateTextPlease()
    {
        
        textBox.GetComponent<Text>().text = _itemText;
        act = DropItem;
        //UnityEditor.Events.UnityEventTools.AddPersistentListener(dropButton.onClick,act);
        
        dropButton.onClick.RemoveAllListeners();        
        dropButton.onClick.AddListener(DropItem);

    }

    public void DropItem()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryUI>().RemoveItem(itemID);
        gameObject.GetComponent<Image>().sprite = null;
        itemText = "";
        gameObject.name = "Empty";
        itemID = 0;

    }

}
