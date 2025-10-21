using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public HealthComponent Health { get; private set; } = new();

    public void Setup(int maxHp)
    {
        Health.Setup(maxHp);
    }
}
