using UnityEngine;

[CreateAssetMenu(menuName = "Assets/EnemyStats",fileName = "EnemyStats")]
public class HealthStatsData : ScriptableObject
{
    public int MaxHp;
    public float BaseSpeed;
}
