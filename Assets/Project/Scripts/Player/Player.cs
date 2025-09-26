using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;

    public event Action MovingStarted;
    public event Action MovingStopped;


    private Vector3 lastMoveDir = Vector3.zero;
    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveDir = InputManager.GetPlayerMove() * speed * Time.deltaTime;
        transform.position += moveDir;

        if(lastMoveDir != moveDir)
        {
            if(moveDir == Vector3.zero)
            {
                MovingStopped?.Invoke();
            }
            else
            {
                MovingStarted?.Invoke();
            }
            lastMoveDir = moveDir;
        }
    }
}
