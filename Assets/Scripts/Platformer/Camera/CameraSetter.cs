using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _cameraHigherOn = 1.5f;
    private float _cameraDepth = -10f;

    private Vector3 position;

    private void Update()
    {
        position = _player.position;
        position.y += _cameraHigherOn;
        position.z = _cameraDepth;

        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }
}
