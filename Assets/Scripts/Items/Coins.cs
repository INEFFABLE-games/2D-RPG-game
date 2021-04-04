using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Coins : AbstractItem
{

    Color textclr;

    private void Start()
    {

        AmountNotify += ChangeText;
        Cost = 1;
        Rarity = (int)Rares.Uncommon;
        itemName = "Coins (" + Amount + ")";
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = itemName;

        ChangeTextColor();

        //Description = "Just a coin";

    }

    void ChangeTextColor()
    {
        switch (Rarity)
        {
            case (int)Rares.Common:

            transform.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.white;

                break;

            case (int)Rares.Uncommon:

            transform.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.green;

                break;

            case (int)Rares.Rare:

            transform.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.blue;

                break;

            case (int)Rares.Legendary:

            transform.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.yellow;

                break;

            case (int)Rares.Mythic:

            transform.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.red;

                break;
        }
    }

    void ChangeText(uint value)
    {
        itemName = "Coins (" + Amount + ")";
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = itemName;
    }

}
