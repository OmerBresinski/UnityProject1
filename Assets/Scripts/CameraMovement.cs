using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const float MAX_SPEED = 3;
    private float _cameraMovementSpeed;
    private float _angularSpeed = 2f;
    private float _rotationAngle;
    private CharacterController _characterController;
    void Start()
    {
        _cameraMovementSpeed = 0f;
        _rotationAngle = 0f;
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        handleMovement();
        handleMouseRotation();
    }

    void handleMovement()
    {
        float speedModifier = 0.5f;
        bool isForwardPressed = Input.GetKey(KeyCode.W);
        bool isBackwardPressed = Input.GetKey(KeyCode.S);
        bool canAccelerate = getCanAccelerate(isForwardPressed, isBackwardPressed, speedModifier);
        if (canAccelerate && isForwardPressed)
        {
            increaseSpeed(speedModifier);
        }
        else if (canAccelerate && isBackwardPressed)
        {
            decreaseSpeed(speedModifier);
        }
        move();
    }

    bool getCanAccelerate(bool isForwardPressed, bool isBackwardPressed, float speedModifier)
    {
        return (isForwardPressed && _cameraMovementSpeed + speedModifier < MAX_SPEED) || (isBackwardPressed && _cameraMovementSpeed - speedModifier > MAX_SPEED * -1);
    }

    void move()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward * Time.deltaTime * _cameraMovementSpeed);
        _characterController.Move(direction);
    }

    void increaseSpeed(float speedModifier)
    {
        _cameraMovementSpeed += speedModifier;
    }

    void decreaseSpeed(float speedModifier)
    {
        _cameraMovementSpeed -= speedModifier;
    }

    void handleMouseRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        _rotationAngle = mouseX * _angularSpeed;
        transform.Rotate(0, _rotationAngle, 0);
    }
}
