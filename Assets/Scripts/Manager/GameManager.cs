using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private GameObject _hitObjectPrefab;
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _gameUI;
    [SerializeField]
    private GameObject _winUI;
    [SerializeField]
    private GameObject _timedText;
    [SerializeField]
    private GameObject _scoreedText;
    [SerializeField]
    private GameObject _highscoreText;
    [SerializeField]
    private TextMeshProUGUI _highscoreTypeText;

    private float _colorChangeTimer;

    private void Awake()
    {
        Instance = this;

        DataManager.HitObjectList.Clear();

        _gameUI.SetActive(true);
        _winUI.SetActive(false);
        _highscoreText.SetActive(false);
    }

    private void Update()
    {
        SpawnHitObject();
        FinshedState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitToMenu();
        }

        if (DataManager.ScoredGameStarted)
            _highscoreTypeText.text = DataManager.Highscore.ToString();
        if (DataManager.TimedGameStarted)
            _highscoreTypeText.text = DataManager.BestTimeInText;
    }

    public void SpawnHitObject()
    {
        if (DataManager.HitObjectList.Count < 1)
        {
            DataManager.HitObjectList.Add(_hitObjectPrefab);
            Instantiate(_hitObjectPrefab);
        }
    }

    public void FinshedState()
    {
        if (DataManager.ScoredGameStarted && DataManager.TimerInSec <= 0f)
        {
            ChangeToWin();

            _scoreedText.SetActive(true);
            _timedText.SetActive(false);
        }
        else if (DataManager.TimedGameStarted && DataManager.Score >= 10000)
        {
            ChangeToWin();

            _scoreedText.SetActive(false);
            _timedText.SetActive(true);
        }
    }

    public void ChangeToWin()
    {
        _gameUI.SetActive(false);
        _winUI.SetActive(true);

        DataManager.FinishedState = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitToMenu()
    {
        HitObject.InGame = false;
        DataManager.TimedGameStarted = false;
        DataManager.ScoredGameStarted = false;

        ResetStats();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("StartScene");
    }

    public void ResetStats()
    {
        DataManager.TotalClicks = 0;
        DataManager.TargetsHit = 0;
        DataManager.Score = 0;

        if (DataManager.ScoredGameStarted)
            DataManager.TimerInSec = 120f;
        else
            DataManager.TimerInSec = 0f;

        DataManager.FinishedState = false;
        DataManager.AccuracyData = "0%";

        _playerPrefab.GetComponent<CameraMovement>().ResetSetup();
    }

    //UI button functions
    public void ResetGame()
    {
        ResetStats();
        SceneManager.LoadScene("PlayScene");
    }

    public void ExitGame()
    {
        HitObject.InGame = false;
        DataManager.TimedGameStarted = false;
        DataManager.ScoredGameStarted = false;

        ResetStats();

        SceneManager.LoadScene("StartScene");
    }
}
