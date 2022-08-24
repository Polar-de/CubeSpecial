using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float mouseSensitivityX;
    [SerializeField] private float mouseSensitivityY;
    [SerializeField] private float moveSpeed;

    
    // Camera Rotation
    private float _rotationX = 0f;
    private float _rotationY = 0f;

    
    // Player
    private CharacterController _characterController;
    private Camera _camera;
    private Vector3 _move;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            CameraRotation();

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            Move();
    }

    private void CameraRotation()
    {
        var inputX = Input.GetAxis("Mouse X");
        var inputY = Input.GetAxis("Mouse Y");

        _rotationX -= inputY * mouseSensitivityY;
        _rotationY += inputX * mouseSensitivityX;
        _rotationX = Math.Clamp(_rotationX, -90f, 90f);
        
        _camera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        transform.rotation  = Quaternion.Euler(0f, _rotationY, 0f);
    }

    private void Move()
    {
        var forward = transform.TransformDirection(Vector3.forward);
        var right = transform.TransformDirection(Vector3.right);
        
        var moveX = Input.GetAxis("Vertical");
        var moveY = Input.GetAxis("Horizontal");

        _move = (forward * moveX) + (right * moveY);
        
        _characterController.Move(_move * moveSpeed * Time.deltaTime);
    }
    
}
