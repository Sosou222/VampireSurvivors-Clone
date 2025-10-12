using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private SpriteRenderer readyToFireSprite;
    [SerializeField] private GameObject projectileSpawner;
    [SerializeField] private float cooldown = 0.8f;

    private Timer cooldownTimer;
    private bool canFire = true;
    void Start()
    {
        cooldownTimer = new Timer(cooldown);
        cooldownTimer.Timeout += OnTimeout;
    }

    void Update()
    {
        cooldownTimer.Update(Time.deltaTime);
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
        if(!canFire)
        {
            return;
        }

        SpawnProjectile();

        canFire = false;
        readyToFireSprite.enabled = false;
        cooldownTimer.Start();
    }

    private void SpawnProjectile()
    {
        Instantiate(projectilePrefab,projectileSpawner.transform.position,transform.rotation);
    }

    private void OnTimeout()
    {
        canFire = true;
        readyToFireSprite.enabled = true;
    }
}
