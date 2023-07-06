using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _sliderSpeed;

    private HeroHealth _health;
    private Slider _slider;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    public void Initialize(HeroHealth health, Slider slider)
    {
        _health = health;
        _slider = slider;

        _slider.value = _health.Current;
    }

    private void OnHealthChanged()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(UpdateHealthBar());
    }

    private IEnumerator UpdateHealthBar()
    {
        while (_slider.value != _health.Current)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.Current,
             Time.fixedDeltaTime * _sliderSpeed);

            yield return null;
        }
    }
}
