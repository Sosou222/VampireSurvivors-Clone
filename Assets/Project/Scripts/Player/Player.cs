using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public WeaponHolder WeaponHolder { get;private set; }

    [SerializeField] private float speed = 6.0f;

    public event Action<Vector3> MovingStarted;
    public event Action<Vector3> MovingStopped;

    private Vector3 lastMoveDir = Vector3.zero;

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
        if(InputManager.IsMouseButtonDown())
        {
            WeaponHolder.FireClickWeapons();
        }
    }
}
