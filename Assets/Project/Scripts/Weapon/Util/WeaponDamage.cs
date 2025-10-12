using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private bool limitedPierce = true;
    [SerializeField] private int pierce = 1;

    public void Setup(bool limitedPierce,int pierce)
    {
        this.limitedPierce = limitedPierce;
        this.pierce = pierce;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if(limitedPierce == false)
            {
                return;
            }

            pierce--;
            if (pierce <= 0)
            {
                Destroy(objectToDestroy);
            }
        }
    }
}
