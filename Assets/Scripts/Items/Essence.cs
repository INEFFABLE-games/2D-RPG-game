using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Essence : AbstractItem
{

    Color textclr;

    public bool isEuipped;

    private void Start()
    {

        AmountNotify += ChangeText;
        isEuipped = false;
        itemType = Type.Equipttable.ToString();
        multiArmor += Random.Range(.05f,.15f);
        multiMagicDamage += Random.Range(.05f,.15f);
        multiSpeed += Random.Range(.05f,.15f);
        multiWeaponDamage += Random.Range(.05f,.15f);


        //Rarity = (int)Rares.Common;
        gameObject.name = itemName;
        itemName = gameObject.name + " (" + Amount + ")";
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = itemName;

        ChangeTextColor();

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
        itemName = gameObject.name + " (" + Amount + ")";
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = itemName;
    }

    public override void EnableItemEffect()
    {

        GameObject plr = GameObject.FindGameObjectWithTag("Player").gameObject;

        plr.GetComponent<CharacterStats>().multiArmorA += multiArmor;
        plr.GetComponent<CharacterStats>().multiMagicDamageA += multiMagicDamage;
        plr.GetComponent<PlayerMovement>().SpeedMulti += multiSpeed;
        plr.GetComponent<CharacterStats>().multiWeaponDamageA += multiWeaponDamage;


    }

    public override void DisableItemEffect()
    {

        GameObject plr = GameObject.FindGameObjectWithTag("Player").gameObject;

        plr.GetComponent<CharacterStats>().multiArmorA -= multiArmor;
        plr.GetComponent<CharacterStats>().multiMagicDamageA -= multiMagicDamage;
        plr.GetComponent<PlayerMovement>().SpeedMulti -= multiSpeed;
        plr.GetComponent<CharacterStats>().multiWeaponDamageA -= multiWeaponDamage;

    }


}
