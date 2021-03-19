using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public GameObject CursorNew;
    private Vector3 target;

    void Start()
    {

        //Cursor.visible = false;
        
    }

    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CursorNew.transform.position = new Vector2(target.x,target.y);
        
    }
}
