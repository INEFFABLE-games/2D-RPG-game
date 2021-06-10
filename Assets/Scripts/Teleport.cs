using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    Transform tpPos;

    void TeleportMe()
    {
        GameObject plr = GameObject.FindGameObjectWithTag("Player");
        plr.transform.position = tpPos.position;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Player")
        {
            TeleportMe();
        }
    }



}
