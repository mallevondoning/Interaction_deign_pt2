using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    [SerializeField]
    private float _baseScore = 100f;
    [SerializeField]
    private float _lowestScore = 10f;
    [SerializeField]
    private float _timeToLowestScore = 3f;

    private int xPos = 0;
    private int yPos = 0;

    private float _addableScore;

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

        GetComponent<Renderer>().material.color = DataManager.HitObjectColor;

        _addableScore = _baseScore;
    }

    private void Update()
    {
        _addableScore -= (_baseScore-_lowestScore)/_timeToLowestScore * Time.deltaTime;
    }

    private void OnDestroy()
    {
        DataManager.LastHitObjectXPos = xPos;
        DataManager.LastHitObjectYPos = yPos;

        DataManager.TargetsHit++;
        DataManager.Score += Mathf.RoundToInt(Mathf.Clamp(_addableScore,_lowestScore,_baseScore));

        DataManager.HitObjectList.Clear();
    }
}
