using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WalkingMonster _template;

    private void Start()
    {
        Instantiate(_template, transform.position, Quaternion.identity);
    }
}
