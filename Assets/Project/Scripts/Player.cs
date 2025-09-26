using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
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
    }
}
