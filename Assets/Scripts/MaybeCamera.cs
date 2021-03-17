using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaybeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Camera myCamera;
    private float _cameraScale = 5;
    private float cameraScale{get{return _cameraScale;}set{if(value > (float)3f && value < (float)10f){_cameraScale = value;}}}
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Mouse ScrollWheel") > 0 )
        {
            myCamera = GetComponent<Camera>();
            cameraScale-=0.5f;
            myCamera.orthographicSize = cameraScale; 
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            myCamera = GetComponent<Camera>();
            cameraScale+=0.5f;
            myCamera.orthographicSize = cameraScale;
        }
        
    }

    

}
