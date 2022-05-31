using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static List<GameObject> HitObjectList = new List<GameObject>();

    //option varibale
    public static float Sensitivity { get; set; } = 100f;
    public static Color RedicalColor { get; set; } = Color.red;

    //
    public static int LastHitObjectXPos { get; set; } = 0;
    public static int LastHitObjectYPos { get; set; } = 0;

    //acc text
    public static int TotalClicks { get; set; } = 0;
    public static int TargetsHit { get; set; } = 0;

    //score text
    public static int Score { get; set; } = 0;
}
