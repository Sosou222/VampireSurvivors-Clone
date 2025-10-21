using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private EnemyAnimator animator;
    [SerializeReference] private ITargetPoint targetPoint;

    [field:SerializeField] public EnemyStats EnemyStats { get; private set; }
    [field:SerializeField] public EnemyView EnemyView { get; private set; }

    public event Action<Vector3> MovingStarted;
    public event Action<Vector3> MovingStopped;

    private Vector3 lastMoveDir = Vector3.zero;
    private Vector3 pointToMoveTo = Vector3.zero;

    private void Start()
    {
        targetPoint.Init();
        EnemyStats.Setup();
        EnemyView.Setup(EnemyStats);

        EnemyStats.Health.HealthZeroReached += OnDie;
    }


    void Update()
    {
        UpdateTargetPoint();
        MoveTowardPoint();
    }

    public void TakeDamage(int damage)
    {
        EnemyStats.TakeDamage(damage);
        DamagePopUpCreator.Instance.CreatePopUp(transform.position, damage);
    }


    private void OnDie()
    {
        animator.TriggerDeath();
        DropsSystem.Instance.Spawn(transform.position, DropItemType.ExpierienceGemSmall);
        animator.DeathAnimationFinished += () => Destroy(gameObject);
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
}
