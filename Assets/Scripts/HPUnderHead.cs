using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUnderHead : MonoBehaviour
{
    public GameObject Character;
    Vector3 Scale;
    void Start()
    {
        Scale = transform.localScale;

    }

    void Update()
    {
        if(Character.GetComponent<AbstractCharacter>())
            Scale.x = (Character.GetComponent<AbstractCharacter>().Health/Character.GetComponent<AbstractCharacter>().MaxHealth)/10;

        transform.localScale = Scale;
    }

}
