using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public HealthComponent Health { get; private set; } = new();
    private float invicibilityTime = 0.5f;
    private Timer invTimer;

    private float speedMult = 1.0f;
    public float SpeedMultiplayer { get { return GetSpeedMult(); } }

    private List<PassiveItemBase> items = new();

    public void Setup(int maxHp)
    {
        Health.Setup(maxHp);
        invTimer = new Timer(invicibilityTime);
    }

    private void Update()
    {
        invTimer.Update(Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        if(invTimer.IsRunning)
        {
            return;
        }
        Health.TakeDamage(damage);
        invTimer.Start();
    }

    public void Heal(int heal) => Health.Heal(heal);

    public void AddPassiveItem(PassiveItemBase item)
    {
        items.Add(item);
        item.OnAdd(this);
    }

    public void RemovePassiveItemsOfType<T>() where T : PassiveItemBase
    {
        foreach(PassiveItemBase item in items)
        {
            if(item.GetType() == typeof(T))
            {
                item.OnRemove(this);
                items.Remove(item);
            }
        }
    }

    public void AddSpeedMult(float mult)
    {
        speedMult += mult;
    }
    public void RemoveSpeedMult(float mult)
    {
        speedMult -= mult;
    }

    public void AddMaxHealth(int maxHp)
    {
        Health.SetMaxHP(Health.MaxHealth + maxHp);
    }

    public void RemoveMaxHealth(int maxHp)
    {
        Health.SetMaxHP(Health.MaxHealth - maxHp);
    }

    private float GetSpeedMult()
    {
        float minMult = 0.25f;
        float maxMult = 3.0f;
        return Mathf.Clamp(speedMult, minMult, maxMult) ;
    }
}
