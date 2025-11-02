using System;
using UnityEngine;

public class HealthComponent
{
    public int Health { get;private set; }
    public int MaxHealth { get; private set; }

    //public event Action<int> HealthChanged;
    //public event Action<int> MaxHealthChanged;
    public event Action<HealthComponent> InfoChanged;
    public event Action HealthZeroReached;

    public void Setup(int maxHealth,int health = -1)
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
        if(health > 0)
        {
            Health = health;
        }
    }

    public void SetMaxHP(int maxHealth)
    {
        MaxHealth = maxHealth;
        //MaxHealthChanged.Invoke(MaxHealth);
        if (Health > MaxHealth)
        {
            Health = maxHealth;
            //HealthChanged.Invoke(Health);
        }

        InfoChanged.Invoke(this);

        if(Health <= 0 )
        {
            HealthZeroReached?.Invoke();
        }
    }

    public void SetHP(int health)
    {
        if(health <= MaxHealth)
        {
            Health = health;
            //HealthChanged.Invoke(Health);
            InfoChanged.Invoke(this);
        }
    }
    public void Heal(int heal)
    {
        Health = Mathf.Min(Health + heal, MaxHealth);
        //HealthChanged.Invoke(Health);
        InfoChanged.Invoke(this);
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(Health - damage, 0);
        //HealthChanged.Invoke(Health);
        InfoChanged.Invoke(this);
        if (Health <= 0)
        {
            HealthZeroReached?.Invoke();
        }
    }

    public float Normalize()
    {
        return (float)(Health)/(float)MaxHealth;
    }

}
