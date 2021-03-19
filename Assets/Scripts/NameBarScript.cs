using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameBarScript : MonoBehaviour
{

    public GameObject Character;
    public GameObject label;
    uint lvl;
    private void Update()
    {
        if (Character.GetComponent<CharacterStats>())
        {
            lvl = Character.GetComponent<CharacterStats>().level;
        }
        else if (Character.GetComponent<EnemyStats>())
        {
            lvl = Character.GetComponent<EnemyStats>().level;
        }

        label.GetComponent<Text>().text = Character.name + " : " + lvl + " lvl.";
    }

}
