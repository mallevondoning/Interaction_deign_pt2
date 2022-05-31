using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextChange : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _score;

    private void Update()
    {
        _score.text = DataManager.Score.ToString();
    }
}
