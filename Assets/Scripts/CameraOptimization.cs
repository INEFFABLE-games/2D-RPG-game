using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOptimization : MonoBehaviour
{
   
   List<GameObject> allObject;

   private void Start() {
      //allObject = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
   }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("TestEnter");    
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("testExit");
    }

}
