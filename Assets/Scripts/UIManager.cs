using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Menu;

    public GameObject Inv;
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
        if(Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }

    }

    public void ESCPressed()
    {
        if(Menu.activeSelf)
        {
            Menu.SetActive(false);
        }
        else if(!Menu.activeSelf)
        {
            Menu.SetActive(true);
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

    void OpenInventory()
    {
        if(Inv.activeSelf)
        {
            Inv.SetActive(false);
        }
        else if(!Inv.activeSelf)
        {
            Inv.SetActive(true);
        }
    }

}
