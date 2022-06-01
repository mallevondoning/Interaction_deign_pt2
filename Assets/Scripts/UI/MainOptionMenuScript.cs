using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainOptionMenuScript : MonoBehaviour
{
    [SerializeField]
    private Scrollbar _mouseSensitivity;
    [SerializeField]
    private Image _redicalColorImage;
    [SerializeField]
    private Image _hitObjectImage;
    [SerializeField]
    private Toggle _invertHorizontal;
    [SerializeField]
    private Toggle _invertVertical;

    [Header("Text")]
    [SerializeField]
    private TextMeshProUGUI _sensitivityPercentText;

    private void Awake()
    {
        _mouseSensitivity.value = Mathf.InverseLerp(50f, 200f, DataManager.Sensitivity);
        _invertHorizontal.isOn = DataManager.InvertedX;
        _invertVertical.isOn = DataManager.InvertedY;

        _hitObjectImage.color = DataManager.HitObjectColor;
    }

    private void Update()
    {
        UpdateMouseSensitivity();
        UpdateInvertedControls();

        //update text
        _sensitivityPercentText.text = UpdatePercentText(_mouseSensitivity.value);

        _redicalColorImage.color = DataManager.RedicalColor;
        _hitObjectImage.color = DataManager.HitObjectColor;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

    public void UpdateMouseSensitivity()
    {
        DataManager.Sensitivity = Mathf.Lerp(10f, 200f, _mouseSensitivity.value);
    }

    public void UpdateInvertedControls()
    {
        DataManager.InvertedX = _invertHorizontal.isOn;
        DataManager.InvertedY = _invertVertical.isOn;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    //button function
    public void UpdateRedicalColor(Image changeColorTo)
    {
        DataManager.RedicalColor = changeColorTo.color;
    }

    public void UpdateHitObjectColor(Image changeColorTo)
    {
        DataManager.HitObjectColor = changeColorTo.color;
    }

    //data function
    public string UpdatePercentText(float normalizedFloat)
    {
        return Mathf.RoundToInt(normalizedFloat * 100).ToString() + "%";
    }
}
