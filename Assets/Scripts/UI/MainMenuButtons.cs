using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void LoadOption()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
