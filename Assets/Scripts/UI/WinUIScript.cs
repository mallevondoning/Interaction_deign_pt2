using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinUIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _highscoreText;
    [SerializeField]
    private GameObject _timedScoreText;
    [SerializeField]
    private GameObject _scoredScoreText;
    [SerializeField]
    private GameObject _accuracyText;

    private float _colorChangeTimer;

    private void Awake()
    {
        _highscoreText.SetActive(false);
    }

    private void Update()
    {
        Highscore();

        _timedScoreText.GetComponent<TextMeshProUGUI>().text = "Your time: " + DataManager.TimerInText;
        _scoredScoreText.GetComponent<TextMeshProUGUI>().text = "Your score: " + DataManager.Score;
        _accuracyText.GetComponent<TextMeshProUGUI>().text = "Your accuracy: " + DataManager.AccuracyData;
    }

    public void Highscore()
    {
        if ((DataManager.ScoredGameStarted && DataManager.TimerInSec < DataManager.BestTimeInSec) || (DataManager.TimedGameStarted && DataManager.Score > DataManager.Highscore))
        {
            _highscoreText.SetActive(true);

            if (DataManager.ScoredGameStarted)
                DataManager.Highscore = DataManager.Score;
            if (DataManager.TimedGameStarted)
            {
                DataManager.BestTimeInSec = DataManager.TimerInSec;
                DataManager.BestTimeInText = DataManager.TimerInText;
            }
        }
        else
        {
            _highscoreText.SetActive(false);
        }

        if (_colorChangeTimer >= 0.2f)
        {
            _highscoreText.GetComponent<TextMeshProUGUI>().color = new Vector4(Random.Range(0f, 1000f) / 1000f, Random.Range(0f, 1000f) / 1000f, Random.Range(0f, 1000f) / 1000f, 0.85f);
            _colorChangeTimer = 0f;
        }

        _colorChangeTimer += Time.deltaTime;
    }
}
