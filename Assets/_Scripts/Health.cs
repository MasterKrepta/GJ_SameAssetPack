using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField]float _currentHealth, _maxHealth;
    public float CurrentHealth { get => _maxHealth; set => _maxHealth = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
