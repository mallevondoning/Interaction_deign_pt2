using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;

    private void Update()
    {
        if (DataManager.ScoredGameStarted)
        {
            DataManager.TimerInSec -= Time.deltaTime;
        }
        else
        {
            DataManager.TimerInSec += Time.deltaTime;
        }

        DataManager.TimerInText = TimerTextFormat();
        _timerText.text = TimerTextFormat();
    }

    public string TimerTextFormat()
    {
        string tempString = "";
        float tempTimer = DataManager.TimerInSec;
        
        //Hour math
        if (DataManager.TimerInSec >= 3600f)
        {
            int hourCheck = Mathf.FloorToInt(tempTimer / 3600f);

            if (hourCheck < 10)
            {
                tempString += "0" + hourCheck + ":";
            }
            else
            {
                tempString += hourCheck + ":";
            }

            tempTimer -= hourCheck * 3600f;
        }

        //minutes math
        if (DataManager.TimerInSec >= 60f)
        {
            int minuteCheck = Mathf.FloorToInt(tempTimer / 60f);

            if (minuteCheck < 10)
            {
                tempString += "0" + minuteCheck + ":";
            }
            else
            {
                tempString += minuteCheck + ":";
            }

            tempTimer -= minuteCheck * 60f;
        }

        //checks if the timer is less then one minute
        if (DataManager.TimerInSec < 60f)
            tempString = "00:";

        //seconds math
        int secondCheck = Mathf.FloorToInt(tempTimer);

        if (secondCheck < 10)
        {
            tempString += "0" + secondCheck;
        }
        else
        {
            tempString += secondCheck.ToString();
        }

        //returns the total timer string
        return tempString;
    }
}
