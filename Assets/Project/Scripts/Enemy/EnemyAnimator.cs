using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public event Action DeathAnimationFinished;

    private void OnEnable()
    {
        enemy.MovingStarted += (direction) => SetRunning(true, direction);
        enemy.MovingStopped += (direction) => SetRunning(false, direction);
    }

    private void OnDisable()
    {
        enemy.MovingStarted -= (direction) => SetRunning(true, direction);
        enemy.MovingStopped -= (direction) => SetRunning(false, direction);
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

    public void TriggerDeath()
    {
        animator.SetTrigger("TrDeath");
    }

    private void OnDeathAniamtionEndCallback()
    {
        DeathAnimationFinished?.Invoke();
    }
}
