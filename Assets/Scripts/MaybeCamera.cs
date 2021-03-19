using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaybeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Camera myCamera;
    public Transform prl;
    private float _cameraScale = 5;
    private float cameraScale{get{return _cameraScale;}set{if(value > (float)3f && value < (float)10f){_cameraScale = value;}}}
    private Vector3 directionMove;

    void Start()
    {
            myCamera = GetComponent<Camera>();
            directionMove =transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Mouse ScrollWheel") > 0 )
        {
            cameraScale-=0.5f;
            myCamera.orthographicSize = cameraScale; 
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cameraScale+=0.5f;
            myCamera.orthographicSize = cameraScale;
        }
 directionMove = Vector3.Lerp(directionMove,prl.position,Time.deltaTime *speed);
 directionMove.z=-10;
        transform.position = directionMove;        
    }

    

}
