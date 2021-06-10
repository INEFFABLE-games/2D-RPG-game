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
        for(float x = 1;x >= 0;x-=.001f)
        {
            Light.GetComponent<Light2D>().intensity = x;
            yield return new WaitForSeconds(.1f);
            //Debug.Log("ToNight");
        }
        StartCoroutine(ToDay());
        yield break;
    }

    IEnumerator ToDay()
    {
        for(float x = 0;x <= 1;x+=.001f)
        {
            Light.GetComponent<Light2D>().intensity = x;
            yield return new WaitForSeconds(.1f);
            //Debug.Log("ToNight");
        }
        StartCoroutine(ToNight());
        yield break;
    }

}
