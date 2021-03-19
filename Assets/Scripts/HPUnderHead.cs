﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUnderHead : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Character;
    Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Character.GetComponent<CharacterStats>())
            localScale.x = Character.GetComponent<CharacterStats>().Health/1500;
        else if(Character.GetComponent<EnemyStats>())
            localScale.x = Character.GetComponent<EnemyStats>().Health/1500;

        transform.localScale = localScale;
    }
}
