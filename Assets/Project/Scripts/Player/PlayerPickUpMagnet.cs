using UnityEngine;

public class PlayerPickUpMagnet : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PickUp pickUp))
        {
            Vector3 dir = (transform.position - pickUp.transform.position).normalized;
            pickUp.gameObject.transform.position += dir * speed * Time.deltaTime;
        }
    }
}
