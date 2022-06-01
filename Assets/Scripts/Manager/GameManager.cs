using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private GameObject _hitObjectPrefab;
    [SerializeField]
    private GameObject _playerPrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        SpawnHitObject();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitToMenu();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetStats();
        }
    }

    public void SpawnHitObject()
    {
        if (DataManager.HitObjectList.Count < 1)
        {
            DataManager.HitObjectList.Add(_hitObjectPrefab);
            Instantiate(_hitObjectPrefab);
        }
    }

    public void QuitToMenu()
    {
        ResetStats();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("StartScene");
    }

    public void ResetStats()
    {
        DataManager.HitObjectList.Clear();

        DataManager.TotalClicks = 0;
        DataManager.TargetsHit = 0;
        DataManager.Score = 0;

        _playerPrefab.GetComponent<CameraMovement>().ResetSetup();
    }
}
