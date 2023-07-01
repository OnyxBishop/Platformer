using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;

    private Coin _coinInstance;

    private float _spawnTime = 2f;

    private bool _isSpawning = true;
    private bool _isOccupied = false;

    private void Start()
    {
        StartCoroutine(SpawnDuringTime());
    }

    private IEnumerator SpawnDuringTime()
    {
        WaitForSeconds _waitForSeconds = new(_spawnTime);

        while (_isSpawning == true)
        {
            Spawn();

            yield return _waitForSeconds;
        }
    }

    private void Spawn()
    {
        if (_isOccupied == false)
        {
            _coinInstance = Instantiate(_coinTemplate, transform.position, Quaternion.identity);

            _isOccupied = true;

            _coinInstance.Collected += OnCoinCollected;
        }
    }

    public void OnCoinCollected()
    {
        Debug.Log(nameof(_coinInstance) + " подобрана");

        _coinInstance.Collected -= OnCoinCollected;

        _isOccupied = false;
    }
}
