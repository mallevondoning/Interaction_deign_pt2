using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    private int xPos = 0;
    private int yPos = 0;

    private float baseScore = 100f;

    private void Awake()
    {
        do
        {
            xPos = Mathf.RoundToInt(Random.Range(-3, 3));
        } while (xPos == DataManager.LastHitObjectXPos);

        do
        {
            yPos = Mathf.RoundToInt(Random.Range(1, 4));
        } while (yPos == DataManager.LastHitObjectYPos);

        transform.position = new Vector3(xPos, yPos, 10);
    }

    private void Update()
    {
        baseScore -= 10 * Time.deltaTime;
    }

    private void OnDestroy()
    {
        DataManager.LastHitObjectXPos = xPos;
        DataManager.LastHitObjectYPos = yPos;

        DataManager.TargetsHit++;
        DataManager.Score += Mathf.RoundToInt(Mathf.Clamp(baseScore,10f,100f));

        DataManager.HitObjectList.Clear();
    }
}
