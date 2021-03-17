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
        playerStats.StateNotify += FillChange;

    }

    void Update()
    {
            
    }

    public virtual void FillChange(string name,float value)
    {
        if(ValueTakeName == "Mana" && name == ValueTakeName)
        {
            filler.fillAmount = (playerStats.mana / playerStats.maxMana);
        }
        if(ValueTakeName == "Health" && name == ValueTakeName)
        {
            filler.fillAmount = (playerStats.Health / playerStats.MaxHealth);
        }
    }

}
