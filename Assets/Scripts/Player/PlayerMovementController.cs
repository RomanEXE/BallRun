using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Rigidbody _rb;

    private void OnEnable()
    {
        Actions.OnGameEnd += DisableMovement;
    }

    private void OnDisable()
    {
        Actions.OnGameEnd -= DisableMovement;
    }

    private void Update()
    {
        Move();
        LimitSpeed();
    }

    private void Move()
    {
        _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        _rb.AddForce(_direction * _speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void LimitSpeed()
    {
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxSpeed);
        }
    }

    private void DisableMovement()
    {
        _rb.isKinematic = true;
        enabled = false;
    }
}