using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private EnemyAnimator animator;
    [SerializeReference] private ITargetPoint targetPoint;

    public event Action<Vector3> MovingStarted;
    public event Action<Vector3> MovingStopped;

    private Vector3 lastMoveDir = Vector3.zero;
    private Vector3 pointToMoveTo = Vector3.zero;

    private void Awake()
    {
        animator.DeathAnimationFinished += Die;
    }

    private void Start()
    {
        targetPoint.Init();
    }


    void Update()
    {
        UpdateTargetPoint();
        MoveTowardPoint();
    }

    private void UpdateTargetPoint()
    {
        pointToMoveTo = targetPoint.GetTargetPoint();
    }

    private void MoveTowardPoint()
    {
        float step = speed * Time.deltaTime;
        Vector3 moveDir = transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, pointToMoveTo, step);
        transform.position = newPos;
        moveDir -= newPos;

        if (lastMoveDir != moveDir)
        {
            if (moveDir == Vector3.zero)
            {
                MovingStopped?.Invoke(moveDir.normalized);
            }
            else
            {
                MovingStarted?.Invoke(moveDir.normalized);
            }
            lastMoveDir = moveDir;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
