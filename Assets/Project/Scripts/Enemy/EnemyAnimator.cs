using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        if (TryGetComponent(out Enemy enemy))
        {
            enemy.MovingStarted += (direction) => SetRunning(true, direction);
            enemy.MovingStopped += (direction) => SetRunning(false, direction);
        }
    }

    private void OnDisable()
    {
        if (TryGetComponent(out Enemy enemy))
        {
            enemy.MovingStarted -= (direction) => SetRunning(true, direction);
            enemy.MovingStopped -= (direction) => SetRunning(false, direction);
        }
    }

    private void SetRunning(bool isRunning, Vector3 direction)
    {
        animator.SetBool("IsRunning", isRunning);
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void TriggerDeath()
    {
        animator.SetTrigger("TrDeath");
    }
}
