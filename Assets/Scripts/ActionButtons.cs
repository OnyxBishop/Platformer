using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtons : MonoBehaviour
{
    [SerializeField] private HeroHealth _hero;

    public void OnDamageButtonClicked()
    {
        _hero.TryTakeDamage();
    }

    public void OnHealButtonClicked()
    {
        _hero.Heal();
    }
}
