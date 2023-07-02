using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{    
    [SerializeField] private float _sliderSpeed;

    private HeroHealth _health;
    private Slider _slider;

    public void Initialize(HeroHealth health, Slider slider)
    {
        _health = health;
        _slider = slider;

        _slider.value = _health.Current;
    }

    private void FixedUpdate()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _health.Current, 
              Time.fixedDeltaTime * _sliderSpeed);
    }
}
