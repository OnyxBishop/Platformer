using UnityEngine;
using UnityEngine.Events;

public class ActionButtons : MonoBehaviour
{
    private HeroHealth _hero;

    private float healButtonValue = 10.5f;
    private float damageButtonValue = 28.125f;

    public void Initialize(HeroHealth hero)
    {
        _hero = hero;
    }

    public void OnHealButtonClicked()
    {
        _hero.Heal(healButtonValue);
    }

    public void OnDamageButtonClicked()
    {
        _hero.TryTakeDamage(damageButtonValue);
    }
}
