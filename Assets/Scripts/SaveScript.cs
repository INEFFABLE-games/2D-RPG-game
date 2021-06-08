using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{

    int currentSceneIndex;
    int scenetocont;

    public void Save()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene",currentSceneIndex);
    }

    public void Load()
    {
        scenetocont = PlayerPrefs.GetInt("SavedGame");
        if(scenetocont != 0)
        {
            SceneManager.LoadScene(scenetocont);
        }
    }

}
