using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    /// <summary>
    /// This is a example
    /// </summary>
    /// 
    public Action<float> OnLifeChange;
    public Action OnDead;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void IncreaseHealth(float toIncrease)
    {
        currentHealth += toIncrease;
        OnLifeChange?.Invoke(currentHealth);
        
    }

    public void DecreaseHealth(float toDecrease)
    {
        
        currentHealth -= toDecrease;
        OnLifeChange?.Invoke(currentHealth);

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(currentHealth <= 0)
        {
            OnDead?.Invoke();
        }
    }

}
