using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public HealthComponent Health { get; private set; } = new();
    private float invicibilityTime = 0.5f;
    private Timer invTimer;
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
}
