using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;


public class DayNightCycle : MonoBehaviour
{
    
    [SerializeField]
    GameObject Light;

    private void Start() {
        StartCoroutine(ToDay());
    }

    IEnumerator ToNight()
    {
        for(int x = 4,y = 54,z = 156;(x < 255 && z < 255 && y < 255);x++,z++,y++)
        {
            Light.GetComponent<Light2D>().color = new Color(x,y,z);
            yield return new WaitForSeconds(1);
            Debug.Log("ToNight");
        }
        StartCoroutine(ToDay());
        yield break;
    }

    IEnumerator ToDay()
    {
        for(int x = 255,y = 255,z = 255;(x < 4 && z < 54 && y < 156);x--,z--,y--)
        {
            Light.GetComponent<Light2D>().color = new Color(x,y,z);
            yield return new WaitForSeconds(1);
            Debug.Log("ToDay");
        }
        StartCoroutine(ToNight());
        yield break;
    }

}
