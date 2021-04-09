using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    Image filler;
    public GameObject plr;
    public string ValueTakeName;
    CharacterStats playerStats;

    void Start()
    {
        filler = GetComponent<Image>();
        playerStats = plr.GetComponent<CharacterStats>();
        playerStats.GenNotify += FillChange;

    }

    public virtual void FillChange(string name,float value,float fval)
    {
        if(name == "mana" && ValueTakeName == "mana")
        {
            filler.fillAmount = (playerStats.mana / playerStats.maxMana);
        }
        if(name == "health" && ValueTakeName == "health")
        {
            filler.fillAmount = (playerStats.Health / playerStats.MaxHealth);
        }
    }

}
