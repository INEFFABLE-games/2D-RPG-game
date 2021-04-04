using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Magic_Ring : AbstractItem
{

    Color textclr;

    public bool isEuipped;

    private void Start()
    {

        AmountNotify += ChangeText;
        Cost = 200;
        isEuipped = false;

        itemType = Type.Equipttable.ToString();
        multiArmor += Random.Range(.1f,.3f);
        multiMagicDamage += Random.Range(.1f,.3f);
        multiSpeed += Random.Range(.1f,.3f);
        multiWeaponDamage += Random.Range(.1f,.3f);


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
