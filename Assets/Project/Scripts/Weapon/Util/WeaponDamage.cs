using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private bool limitedPierce = true;
    [SerializeField] private int pierce = 1;
    private int damage = 0;

    public void SetPierce(bool limitedPierce,int pierce)
    {
        this.limitedPierce = limitedPierce;
        this.pierce = pierce;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
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
