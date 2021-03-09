using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBAr : MonoBehaviour
{
    // Start is called before the first frame update

    Image filler;
    public GameObject plr;
    PlayerStats playerStats;

    void Start()
    {
        filler = GetComponent<Image>();
        playerStats = plr.GetComponent<PlayerStats>();
        playerStats.StateNotify += FillChange;

    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void FillChange(string name,float value)
    {
        if(name == "Health")
        {
            filler.fillAmount = (playerStats.Health / playerStats.MaxHealth);
        }
    }

}
