using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameBarScript : MonoBehaviour
{

    public GameObject Character;
    public GameObject label;
    private void Update()
    {
            uint lvl = Character.GetComponent<CharacterStats>().level;
            label.GetComponent<Text>().text = Character.name + " : " + lvl + " lvl.";
    }

}
