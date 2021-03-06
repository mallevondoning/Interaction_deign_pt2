using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static List<GameObject> HitObjectList = new List<GameObject>();

    //option varibale
    public static Color RedicalColor { get; set; } = Color.red;
    public static Color HitObjectColor { get; set; } = Color.gray;
    public static float Sensitivity { get; set; } = 100f;
    public static bool InvertedX { get; set; } = false;
    public static bool InvertedY { get; set; } = false;

    public static float TimerInSec { get; set; } = 0f;
    public static bool FinishedState { get; set; } = false;
    public static bool ScoredGameStarted { get; set; } = false;
    public static bool TimedGameStarted { get; set; } = false;
    public static string TimerInText { get; set; } = "00:00";

    //postion data of HitObject
    public static int LastHitObjectXPos { get; set; } = 0;
    public static int LastHitObjectYPos { get; set; } = 0;

    //acc text
    public static int TotalClicks { get; set; } = 0;
    public static int TargetsHit { get; set; } = 0;

    //score text
    public static int Score { get; set; } = 0;

    //highscore data
    public static int Highscore { get; set; } = 0;
    public static float BestTimeInSec { get; set; } = float.MaxValue;
    public static string BestTimeInText { get; set; } = "00:00";
    public static string AccuracyData { get; set; } = "0%";
}
