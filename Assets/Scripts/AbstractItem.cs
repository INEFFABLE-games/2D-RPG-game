﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractItem : MonoBehaviour
{
    protected delegate void AmountChange(uint value);
    protected event AmountChange AmountNotify;

    public enum Rares
    {
        Common = 1,
        Uncommon,
        Rare,
        Legendary,
        Mythic
    }

    public enum Type
    {
        Equipttable = 1,
        Usable,
        Nothing
    }

    [SerializeField]
    public bool equipped;
    [SerializeField]
    string _itemName;

    [SerializeField]
    public uint _Amount;
    [SerializeField]
    uint _Cost;

    [SerializeField]
    int _Rarity;

    [SerializeField]
    string _itemType;

    public string Description;

    public uint Amount{get{return _Amount;}set{_Amount = value;AmountNotify?.Invoke(value);}}
    public uint Cost{get{return _Cost;}set{_Cost = value;}}
    public int Rarity{get{return _Rarity;}set{_Rarity = value;}} 
    public string itemName{get{return _itemName;}set{_itemName = value;}}
    public string itemType{get{return _itemType;}set{_itemType = value;}}
    

}
