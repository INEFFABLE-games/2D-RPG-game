using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUnderHead : MonoBehaviour
{
    public GameObject Character;
    Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;

    }

    void Update()
    {
        if(Character.GetComponent<AbstractCharacter>())
            localScale.x = Character.GetComponent<AbstractCharacter>().Health/1500;

        transform.localScale = localScale;
    }

}
