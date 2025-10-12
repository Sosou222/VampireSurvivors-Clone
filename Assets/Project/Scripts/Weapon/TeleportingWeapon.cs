using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class TeleportingWeapon : Weapon
{
    [SerializeField] private GameObject teleportingWeaponPrefab;
    [SerializeField] private float range = 1.0f;
    [SerializeField] private LayerMask enemyLayerMask;

    private Timer cooldownTimer;
    private bool canFire = true;

    private void Start()
    {
        cooldownTimer = new Timer(cooldown);
        cooldownTimer.Timeout += OnTimeout;
    }

    protected override void Update()
    {
        cooldownTimer.Update(Time.deltaTime);
        Fire();
    }

    public override void Fire()
    {
        if(!canFire)
        {
            return;
        }

        if(TryFindClosestEnemy(out Enemy enemy))
        {
            CreateSword(enemy.gameObject.transform.position);
            canFire = false;
            cooldownTimer.Start();
        }
    }

    private bool TryFindClosestEnemy(out Enemy enemy)
    {
        List<Collider2D> colliders = Physics2D.OverlapCircleAll(transform.position, range, enemyLayerMask).ToList();
        enemy = null;
        foreach(Collider2D collider in colliders)
        {
            if(collider.gameObject.TryGetComponent(out Enemy e))
            {
                if(enemy == null)
                {
                    enemy = e;
                }
                else
                {
                    Vector2 posEnemyOld = enemy.gameObject.transform.position;
                    Vector2 posEnemyNew = e.gameObject.transform.position;

                    float disOld = Vector2.Distance(posEnemyOld,transform.position);
                    float disNew = Vector2.Distance(posEnemyNew, transform.position);

                    if(disNew < disOld)
                    {
                        enemy = e;
                    }
                }
            }
        }
        if (enemy == null) return false;
        return true;
    }

    private void CreateSword(Vector3 position)
    {
        Instantiate(teleportingWeaponPrefab, position, Quaternion.identity);
    }

    private void OnTimeout()
    {
        canFire = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
