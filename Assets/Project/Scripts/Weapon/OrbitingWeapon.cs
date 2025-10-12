using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class OrbitingWeapon : Weapon
{
    [SerializeField] private GameObject orbitingWeaponPrefab;
    [SerializeField] private float rotationSpeed = 80.0f;
    [SerializeField] private float radius = 3.0f;

    private List<GameObject> orbitingWeapons = new();

    private void Start()
    {
        AddOrbitingWeapon();
    }

    protected override void Update()
    {
        UpdateRotation();
        if(Input.GetKeyDown(KeyCode.R))
        {
            AddOrbitingWeapon();
        }
    }

    private void UpdateRotation()
    {
        float angle = rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0,0,angle));
    }

    private void AddOrbitingWeapon()
    {
        GameObject orbit = Instantiate(orbitingWeaponPrefab,transform);
        orbitingWeapons.Add(orbit);
        PlaceOrbitingObjects();
    }

    private void PlaceOrbitingObjects()
    {
        for (int i = 0; i < orbitingWeapons.Count; i++)
        {
            float angle = i * Mathf.PI * 2f / orbitingWeapons.Count;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            Vector3 position = new Vector3(x, y, 0f);
            orbitingWeapons[i].transform.position = position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
