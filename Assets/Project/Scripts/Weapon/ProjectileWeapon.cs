using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private GameObject projectileSpawner;
    void Start()
    {
        
    }

    void Update()
    {
        UpdateRotation();
        if(InputManager.IsMouseButtonDownThisFrame())
        {
            Fire();
        }
    }

    private void UpdateRotation()
    {
        Vector3 mousePos = InputManager.GetMouseScreenPosition();

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y, Camera.main.nearClipPlane));
        Vector2 rotateDir = (worldPos - transform.position).normalized;
        float angle = Mathf.Atan2(rotateDir.y, rotateDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void Fire()
    {
        SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab,projectileSpawner.transform.position,transform.rotation);
    }
}
