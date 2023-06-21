using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 position;

    private void Awake()
    {
        if (!_player)
            _player = FindObjectOfType<HeroMovement>().transform;
    }

    private void Update()
    {
        position = _player.position;
        position.y += 1.5f;
        position.z = -10f;

        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }
}
