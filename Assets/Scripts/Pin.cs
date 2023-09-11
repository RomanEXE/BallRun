using System;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private Ray _ray;
    [SerializeField] private Transform _rayPoint;

    private void Start()
    {
        _ray = new Ray(_rayPoint.position, transform.forward * 50);
    }

    private void Update()
    {
        Debug.DrawRay(_rayPoint.position, transform.forward * 100f, Color.red);
        if (Physics.Raycast(_ray, out var hit))
        {
            Actions.OnPinDrop.Invoke();
            enabled = false;
        }
    }
}