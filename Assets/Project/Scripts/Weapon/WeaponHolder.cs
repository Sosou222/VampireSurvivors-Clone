using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    private Dictionary<WeaponData,Weapon> weapons = new();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Add(weaponData);
        }
    }

    public void Add(WeaponData data)
    {
        if(!weapons.ContainsKey(data))
        {
            Weapon weapon = Instantiate(data.weaponPrefab,transform);
            weapon.Setup(data);
            weapons.Add(data, weapon);
        }
        else
        {
            Debug.LogWarning("Player has aleady that weapon");
        }
    }
}
