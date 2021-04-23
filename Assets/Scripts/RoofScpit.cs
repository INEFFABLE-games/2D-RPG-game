using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofScpit : MonoBehaviour
{
    [SerializeField]
    GameObject roof;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Staying...");
            if(roof.gameObject.activeSelf == true)
            roof.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Exited...");
            if(roof.gameObject.activeSelf == false)
                roof.gameObject.SetActive(true);
        }
    }

}
