using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonster : MonoBehaviour
{
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layer;
    
    private float _speed = 3.5f;

    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _direction = transform.right;

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction, _distanceRay, _layer);

        if (hit == true)
        {
            _direction *= -1;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }

        transform.Translate(_speed * Time.deltaTime * _direction);
    }
}
