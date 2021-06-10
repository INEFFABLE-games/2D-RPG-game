using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatsUpper : MonoBehaviour
{

    static uint _cost;

    private void Start() {
        
        _cost = 100;

    }


    public void Up()
    {
        if(GameObject.FindGameObjectWithTag("ItemsFolder").transform.Find("Coins").gameObject.GetComponent<AbstractItem>().Amount >= _cost)
        {
            GameObject.FindGameObjectWithTag("ItemsFolder").transform.Find("Coins").gameObject.GetComponent<AbstractItem>().Amount -= _cost;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AbstractCharacter>().level++;
        }
    }

}
