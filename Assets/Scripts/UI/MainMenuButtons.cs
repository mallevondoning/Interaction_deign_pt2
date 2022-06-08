using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenu;
    [SerializeField]
    private GameObject _gamemode;

    private void Awake()
    {
        ChangeToMainMenu();
    }

    public void LoadNormalGame()
    {
        HitObject.InGame = true;
        SceneManager.LoadScene("PlayScene");
    }

    public void LoadScoredGame()
    {
        DataManager.ScoredGameStarted = true;
        DataManager.TimerInSec = 120f;

        LoadNormalGame();
    }

    public void LoadTimedGame()
    {
        DataManager.TimedGameStarted = true;

        LoadNormalGame();
    } 

    public void LoadOption()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void ChangeToGamemodes()
    {
        _mainMenu.SetActive(false);
        _gamemode.SetActive(true);
    }
    public void ChangeToMainMenu()
    {
        _mainMenu.SetActive(true);
        _gamemode.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
