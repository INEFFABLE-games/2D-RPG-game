using System.Collections;
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
        localScale.x = Character.GetComponent<CharacterStats>().Health/2000;
        transform.localScale = localScale;
    }
}
