using Platformer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour, IHittable
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    public int CurrentHealth
    {
        get => currentHealth;
        set { 
            currentHealth = value;
            OnHealthValueChange?.Invoke(currentHealth);
            
        }
    }

    [field:SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    public UnityEvent OnAddHealth;

    public UnityEvent<int> OnHealthValueChange = new UnityEvent<int>();

    public UnityEvent<int> OnInitializeMaxHealth = new UnityEvent<int>();

    public void GetHit(int val)
    {
        CurrentHealth -= val;
        if(CurrentHealth <= 0)
        {
            OnDie?.Invoke();
        }
        else
        {
            OnGetHit?.Invoke();
        }

    }

    public void AddHealth(int val)
    {
        CurrentHealth = Mathf.Clamp(currentHealth + val, 0, maxHealth);
        OnAddHealth?.Invoke();
    }

    public void Initialize(int health)
    {
        maxHealth = health;
        OnInitializeMaxHealth?.Invoke(maxHealth);
        CurrentHealth = maxHealth;
    }

    public void GetHit(GameObject opponent, int damageAmount)
    {
        GetHit(damageAmount);
    }
}
