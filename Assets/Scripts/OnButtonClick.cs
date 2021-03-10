using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    // Start is called before the first frame update

    public new string name;
    public Canvas Menu;
    public GameObject gameLogic;
    GameLogic gameLog;
    bool isMenuOpened;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyButtonAction()
    {

        if (Menu.enabled)
        {
            Menu.enabled = false;
            //new WaitForEndOfFrame();
        }

    }

}
