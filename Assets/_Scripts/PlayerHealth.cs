using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float _currentHealth, _maxHealth;
    public Image healthBar;
    Animator anim;
    public float CurrentHealth { 
        get => _currentHealth;
        set {
            _currentHealth = value;
            healthBar.fillAmount = _currentHealth / MaxHealth;
            CheckDeath();
        }
    }
    public float MaxHealth { get => _maxHealth;  set =>_maxHealth = value;}

    private void CheckDeath()
    {
        if (CurrentHealth <= 0)
        {
            print("Player dies");
        }
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;
        anim.SetTrigger("hit");
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
    }
 
}
