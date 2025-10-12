using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private HealthStatsData healthStatsData;
    public HealthComponent Health { get; private set; } = new();
    public float BaseSpeed => healthStatsData.BaseSpeed;
    private float speedMultiplayer = 1.0f;
    public float SpeedMultiplier { get { return GetSpeedMult(); } }
    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        Health.Setup(healthStatsData.MaxHp);
    }

    public void TakeDamage(int damage) => Health.TakeDamage(damage);
    public void Heal(int heal) => Health.Heal(heal);

    public void AddSpeedMult(float add)
    {
        speedMultiplayer += add;
    }

    public void RemoveSpeedMult(float remove) 
    { 
        speedMultiplayer -= remove;
    }

    private float GetSpeedMult()
    {
        if(speedMultiplayer < 0.0f)
        {
            return 0.0f;
        }
        return speedMultiplayer;
    }
}
