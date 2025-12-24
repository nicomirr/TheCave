using System;
using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _gravityScale = 3f;
    [SerializeField] private float _jumpForce = 5f;       

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GameEvents.OnDisablePause += EnableGravity;
    }

    private void OnDisable()
    {
        GameEvents.OnDisablePause -= EnableGravity;
    }

    public void Jump()
    {
        if (!GameManager.Instance.IsRunning) return;

        _rb.AddForceY(_jumpForce, ForceMode2D.Impulse);
        GameEvents.RaisePlayerJump();
    }    

    private void EnableGravity()
    {
        _rb.gravityScale = _gravityScale;
    }
}
