using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Weapon",fileName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public Weapon weaponPrefab;
    [MinValue(1)]
    public int MaxLevel;
    public bool UsesKeyToFire;
    [RequiredListLength("@this.MaxLevel", "@this.MaxLevel")]
    public List<int> Damage;
    [RequiredListLength("@this.MaxLevel", "@this.MaxLevel")]
    public List<float> CoolDown;
}
