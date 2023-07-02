using UnityEngine;
using UnityEngine.UI;

public class HealthBootstrap : MonoBehaviour
{
    [SerializeField] private HeroHealth _heroHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Slider _slider;
    [SerializeField] private ActionButtons _buttons;

    private void Awake()
    {
        _heroHealth.Initialize();
        _healthBar.Initialize(_heroHealth, _slider);
        _buttons.Initialize(_heroHealth);
    }
}
