using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        if(TryGetComponent(out Player player))
        {
            player.MovingStarted += () => SetRunning(true);
            player.MovingStopped += () => SetRunning(false);
        }
    }

    private void OnDisable()
    {
        if (TryGetComponent(out Player player))
        {
            player.MovingStarted -= () => SetRunning(true);
            player.MovingStopped -= () => SetRunning(false);
        }
    }

    private void SetRunning(bool isRunning)
    {
        animator.SetBool("IsRunning",isRunning);
    }

    private void TriggerDeath()
    {
        animator.SetTrigger("TrDeath");
    }
}
