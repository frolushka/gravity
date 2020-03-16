using System;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private Camera cachedCamera;
    [SerializeField] private float gravity;

    private Rigidbody2D _rb;

    private Vector3 _position;
    private Vector3 _curDirection;
    private Vector3 _newDirection;
    private bool _mouseDown;

    private float _startRotation;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _position = transform.position;
    }

    private void OnMouseDown()
    {
        _curDirection = cachedCamera.ScreenToWorldPoint(Input.mousePosition) - _position;
        _curDirection.z = _position.z;
        _curDirection.Normalize();
        _startRotation = transform.eulerAngles.z;
        _mouseDown = true;
    }

    private void OnMouseUp()
    {
        _mouseDown = false;
    }

    private void Update()
    {
        if (!_mouseDown) return;

        _newDirection = cachedCamera.ScreenToWorldPoint(Input.mousePosition) - _position;
        _newDirection.z = _position.z;
        _newDirection.Normalize();
        
        Debug.DrawLine(_position, _position + _curDirection, Color.green);
        Debug.DrawLine(_position, _position + _newDirection, Color.red);
        var angle = Vector3.SignedAngle(_curDirection, _newDirection, Vector3.forward);
        _rb.SetRotation(_startRotation + angle);

        Physics2D.gravity = transform.up * -gravity;
    }
}
