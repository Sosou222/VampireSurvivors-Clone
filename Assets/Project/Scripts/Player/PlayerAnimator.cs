using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        if(TryGetComponent(out Player player))
        {
            player.MovingStarted += (direction) => SetRunning(true, direction);
            player.MovingStopped += (direction) => SetRunning(false, direction);
        }
    }

    private void OnDisable()
    {
        if (TryGetComponent(out Player player))
        {
            player.MovingStarted -= (direction) => SetRunning(true, direction);
            player.MovingStopped -= (direction) => SetRunning(false, direction);
        }
    }

    private void SetRunning(bool isRunning,Vector3 direction)
    {
        animator.SetBool("IsRunning",isRunning);
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(direction.x > 0) 
        {
            spriteRenderer.flipX = false;
        }
    }

    private void TriggerDeath()
    {
        animator.SetTrigger("TrDeath");
    }
}
