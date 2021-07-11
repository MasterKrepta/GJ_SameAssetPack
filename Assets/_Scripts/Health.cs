using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField]float _currentHealth, _maxHealth;
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    public GameObject destroyed;

   

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;
        if (CurrentHealth <= 0) 
        {
            Instantiate(destroyed, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    
}
