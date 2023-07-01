using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _sliderSpeed;

    private const float MAX_HEALTH = 100f;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = MAX_HEALTH;
        _healthBar.value = _currentHealth;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    public void TryTakeDamage()
    {
        if (_currentHealth >= 0)
        {
            float damage = 10f;
            _currentHealth -= damage;
        }
    }

    public void Heal()
    {
        if (_currentHealth <= MAX_HEALTH)
        {
            float healValue = 10f;
            _currentHealth += healValue;
        }
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentHealth, Time.deltaTime * _sliderSpeed);
    }
}
