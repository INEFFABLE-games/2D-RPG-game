using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WeaponManager : MonoBehaviour
{
    
    public GameObject player;
    CharacterStats playerStats;
    public string WeaponName;
    public string MakingResource;
    public string Affect1;
    public string Affect2;
    public string Affect3;
    public string GetMethod;
    public string CreatorRase;
    public string Location;
    public float ReqLevel;
    public float UpdateCost;
    public float Cost;
    private void Start() {

        playerStats = player.GetComponent<CharacterStats>();

    }

    public virtual void Aff1()
    {

    }



}
