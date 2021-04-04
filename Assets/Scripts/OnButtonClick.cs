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
        }
        else if(!Menu.activeSelf)
        {
            Menu.SetActive(true);
        }

    }

}
