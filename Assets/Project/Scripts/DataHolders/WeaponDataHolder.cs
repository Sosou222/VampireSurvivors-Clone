using System.Collections.Generic;
using UnityEngine;

public class WeaponDataHolder : Singleton<WeaponDataHolder>
{
    [SerializeField] private List<WeaponData> weapons;

    public List<WeaponData> GetWeaponList()
    {
        return weapons;
    }
}
