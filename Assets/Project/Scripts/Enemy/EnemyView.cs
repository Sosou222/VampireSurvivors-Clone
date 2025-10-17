using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private FloatingHealthBar healthBar;
    public void Setup(EnemyStats enemyStats)
    {
        healthBar.Setup(enemyStats.Health);
    }
}
