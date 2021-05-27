using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryStatsUpdater : MonoBehaviour
{
    void UpdateStats(string name,float value, float fval)
    {
        StatsText.GetComponent<Text>().text = $"Name: {PlayerStats.name}\nLevel: {PlayerStats.level}\nEXP:   {Mathf.Floor(PlayerStats.exp)}/{Mathf.Floor(PlayerStats.maxExp)}\nMana: {Mathf.Floor(PlayerStats.mana)}/{Mathf.Floor(PlayerStats.maxMana)}\nArmor Multipier: {PlayerStats.multiArmorA}\nMagic Level: {Mathf.Floor(PlayerStats.magicLevel)}\nWeapon Level: {Mathf.Floor(PlayerStats.weaponDamage)}\nReputation {Mathf.Floor(PlayerStats.reputation)}";
    }
   
   AbstractCharacter PlayerStats;
   GameObject StatsText;
   bool isUpdating;
   
    void Start()
    {
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<AbstractCharacter>();
        StatsText = GameObject.FindGameObjectWithTag("InventoryStatsText");
        isUpdating = false;

        UpdateStats("x",1f,1f);

        PlayerStats.GenNotify += UpdateStats;

    }
        
}
