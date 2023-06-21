using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;
    float _verticalRotation;
    float _horizontalRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontalMovement, 0, forwardMovement);

        _horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        _verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_verticalRotation, _horizontalRotation, 0);
    }
}