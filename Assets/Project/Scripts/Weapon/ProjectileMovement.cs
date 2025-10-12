using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
