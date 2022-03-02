using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    private bool _isFacingLeft = false;

    public float moveSpeed = 5f;
    public Vector2 movement;

    private void Start()
    {
        // _animator = GetComponent<Animator>();
        //_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        CheckCharacterDirection();
        _animator.SetBool("IsMoving", IsMoving());
    }

    private void CheckCharacterDirection()
    {
        if ((movement.x > 0 && _isFacingLeft) || movement.x < 0 && !_isFacingLeft)
        {
            FlipCharacter();
        }

    }

    private void FlipCharacter()
    {
        _isFacingLeft = !_isFacingLeft;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private bool IsMoving()
    {
        return (movement.x != 0 || movement.y != 0);
    }

    // 50 times per second
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
