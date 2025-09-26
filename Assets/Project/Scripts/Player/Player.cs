using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;

    public event Action<Vector3> MovingStarted;
    public event Action<Vector3> MovingStopped;

    private Timer attackTimer;

    private Vector3 lastMoveDir = Vector3.zero;
    private bool canAttack = false;
    void Start()
    {
        attackTimer = new Timer(1.0f,true,true);
        attackTimer.Timeout += OnAttackTimeout;
    }

    private void OnEnable()
    {
        PlayerInfoSystem.Instance.SetPlayer(this);
    }

    private void OnDisable()
    {
        if(PlayerInfoSystem.Instance != null)
            PlayerInfoSystem.Instance.SetPlayer(null);
    }

    void Update()
    {
        attackTimer.Update(Time.deltaTime);
        MovePlayer();
        TryAttack();
    }

    private void MovePlayer()
    {
        Vector3 moveDir = InputManager.GetPlayerMove() * speed * Time.deltaTime;
        transform.position += moveDir;

        if(lastMoveDir != moveDir)
        {
            if(moveDir == Vector3.zero)
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

    private void TryAttack()
    {
        if(InputManager.IsMouseButtonDown() && canAttack)
        {
            canAttack = false;
            attackTimer.Start();
            Debug.Log("HI");
        }
    }

    private void OnAttackTimeout()
    {
        canAttack = true;
    }
}
