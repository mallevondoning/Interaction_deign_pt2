using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("PlayScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("PlayScene"));
    }

    public void LoadOption()
    {
        Debug.Log("It works");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
