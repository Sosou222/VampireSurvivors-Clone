using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private FloatingHealthBar healthBar;

    public void Setup(PlayerStats stats)
    {
        healthBar.Setup(stats.Health,true);
    }
}
