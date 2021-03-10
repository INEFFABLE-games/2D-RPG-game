using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas Menu;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ESCPressed();
        }

    }

    public void ESCPressed()
    {
        if (!Menu.enabled)
        {
            Menu.enabled = true;
            //new WaitForEndOfFrame();
        }
        else if (Menu.enabled)
        {
            Menu.enabled = false;
            //new WaitForEndOfFrame();
        }
    }

}
