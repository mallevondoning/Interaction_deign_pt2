using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AccuracyTextChange : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _acc;

    private void Update()
    {
        if (DataManager.TotalClicks == 0)
            _acc.text = "0%";
        else
        {
            float percent = (float)DataManager.TargetsHit / DataManager.TotalClicks;
            int visualPercent = Mathf.RoundToInt(percent * 100);
            _acc.text = visualPercent.ToString() + "%";
        }
    }
}
