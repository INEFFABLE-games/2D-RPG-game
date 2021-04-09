using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameBarScript : MonoBehaviour
{

    public GameObject Character;
    public GameObject label;
    bool startUpdate;
    uint lvl;

    private void Start() {
        startUpdate = false;
    }

    IEnumerator UpdateState()
    {
        startUpdate = true;

            lvl = Character.GetComponent<AbstractCharacter>().level;
            label.GetComponent<Text>().text = Character.name + " : " + lvl + " lvl.";
        
            float reputation = Character.GetComponent<AbstractCharacter>().reputation;

            if(reputation <= -1500)
            {
                label.GetComponent<Text>().color = new Color(122, 0, 171, 1); 
                label.GetComponent<Text>().text = "(Demon)" + Character.name + " : " + lvl + " lvl.";
            }
            else if(reputation > -1500 && reputation < 0)
            {
                label.GetComponent<Text>().color = Color.red; 
                label.GetComponent<Text>().text = "(Bandit)" + Character.name + " : " + lvl + " lvl.";
            }
            else if(reputation >= 0 && reputation < 1500)
            {
                label.GetComponent<Text>().color = Color.white; 
                label.GetComponent<Text>().text = "(Friendly)" + Character.name + " : " + lvl + " lvl.";
            }
            else if(reputation >= 1500)
            {
                label.GetComponent<Text>().color = Color.green; 
                label.GetComponent<Text>().text = "(Hero)" + Character.name + " : " + lvl + " lvl.";
            }

        yield return new WaitForSeconds(1f);

        startUpdate = false;

        yield break;
    }

    private void Update()
    {
        if(!startUpdate)
            StartCoroutine(UpdateState());

    }

}
