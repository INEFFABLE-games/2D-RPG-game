using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public static void Start_Game()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadSceneAsync("MainWorld", LoadSceneMode.Single);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainWorld"));

    }

}
