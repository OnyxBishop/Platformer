using UnityEngine;
using UnityEngine.UI;

public class HealthBootstrap : MonoBehaviour
{    
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Slider _slider;
    [SerializeField] private ActionButtons _buttons;

    private HeroHealth _heroHealth = new();

    private void Awake()
    {
        _healthBar.Initialize(_heroHealth, _slider);
        _buttons.Initialize(_heroHealth);
    }
}
