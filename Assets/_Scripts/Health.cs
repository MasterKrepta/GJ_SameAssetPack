using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField]float _currentHealth, _maxHealth;
    public Image healthBar;
    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            if (healthBar !=null)
                healthBar.fillAmount = CurrentHealth / MaxHealth;
        }
    }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    public GameObject destroyed;
    Animator anim;

    


    public void TakeDamage(float dmg)
    {
        anim.SetTrigger("hit");
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
        anim = GetComponent<Animator>();
    }

    
}
