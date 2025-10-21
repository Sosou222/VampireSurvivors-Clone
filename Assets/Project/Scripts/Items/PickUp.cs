using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeReference] private IPickUpBehaviour pickUpBehaviour;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            pickUpBehaviour.OnPickUp(player);
            Destroy(gameObject);
        }
    }
}
