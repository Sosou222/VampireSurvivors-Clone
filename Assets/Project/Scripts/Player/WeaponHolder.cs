using System.Collections.Generic;
using System.Linq;
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

    public List<WeaponData> GetWeaponData()
    {
        return weapons.Keys.ToList();
    }

    public void LevelUpWeapon(WeaponData data)
    {
        if(weapons.ContainsKey(data))
        {
            weapons[data].LevelUp();
        }
    }

    public int GetWeaponLevel(WeaponData data)
    {
        if (weapons.ContainsKey(data))
        {
            return weapons[data].Level;
        }
        return -1;
    }

    public void FireClickWeapons()
    {
        List<Weapon> clickWeapons = weapons.Values.Where(w=>w.UsesKeyToFire == true).ToList();
        foreach(Weapon w in clickWeapons) 
        {
            w.Fire();
        }
    }
}
