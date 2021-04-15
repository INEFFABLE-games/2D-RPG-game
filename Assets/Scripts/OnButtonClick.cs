using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
 
    public GameObject Menu;
   
    bool isMenuOpened;

    public void MyButtonAction()
    {

        if (Menu.activeSelf)
        {
            Menu.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AbstractCharacter>().CanShoot = true;
        }
        else if(!Menu.activeSelf)
        {
            Menu.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AbstractCharacter>().CanShoot = false;
        }

    }

}
