using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu1 : MonoBehaviour
{
    public static void End_Game()
    {
        SceneManager.UnloadSceneAsync("MainWorld");
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));

    }
}
