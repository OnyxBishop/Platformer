using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private States State
    {
        get { return (States)_animator.GetInteger(nameof(State)); }
        set { _animator.SetInteger(nameof(State), (int)value); }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isGrounded == true)
            State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();

        if (_isGrounded == true && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Run()
    {
        State = States.run;

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);

        _sprite.flipX = direction.x < 0.0f;
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        float overlapRadius = 0.8f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, overlapRadius);

        _isGrounded = colliders.Length > 1;
    }
}

public enum States
{
    idle,
    run
}