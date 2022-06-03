using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera _playerCamera;
    [SerializeField]
    private Animation _recoilAnimation;
    [SerializeField]
    private Image _redicalImage;

    [SerializeField]
    private float _maxXRot = 45f;
    [SerializeField]
    private float _maxYRot = 60f;

    private float _xRot;
    private float _yRot;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ResetSetup();
        _redicalImage.color = DataManager.RedicalColor;
    }

    void Update()
    {
        RotateCamera();
        ShootLaser();
    }

    public void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * DataManager.Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * DataManager.Sensitivity * Time.deltaTime;

        if (!DataManager.InvertedX)
            _xRot += mouseX;
        else
            _xRot -= mouseX;
        _xRot = Mathf.Clamp(_xRot, -_maxXRot, _maxXRot);

        if(!DataManager.InvertedY)
            _yRot -= mouseY;
        else
            _yRot += mouseY;
        _yRot = Mathf.Clamp(_yRot, -_maxYRot, _maxYRot);

        _playerCamera.transform.rotation = Quaternion.Euler(_yRot, _xRot, 0f);
    }

    public void ShootLaser()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LayerMask mask = LayerMask.GetMask("HitObject");
            Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out RaycastHit _hit, float.MaxValue, mask);

            DataManager.TotalClicks++;

            _recoilAnimation.Play("Recoil");

            if (_hit.transform != null)
                Destroy(_hit.transform.gameObject);
        }
    }

    public void ResetSetup()
    {
        _playerCamera.transform.rotation = Quaternion.Euler(0, 0, 0f);
    }
}
