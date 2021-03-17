using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas Menu;
    public Canvas Options;
    public AudioMixer audioMixer;
    void Start()
    {

        //Menu.enabled = false;
        //Options.enabled = false;

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
            new WaitForEndOfFrame();
        }
        else if (Menu.enabled)
        {
            if(Options.enabled)
            Options.enabled = false;

            Menu.enabled = false;

            new WaitForEndOfFrame();
        }
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume",vol);
        //Debug.Log("Volume: " + vol);
    }

    public void FullScreenSetter(bool value)
    {
        Screen.fullScreen = value;
    }


}
