using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected WeaponData weaponData;
    public int Level { get; private set; } = 1;
    public int MaxLevel => weaponData.MaxLevel;
    public int Damage => weaponData.Damage[Level - 1];
    protected float cooldown => weaponData.CoolDown[Level - 1];

    public void Setup(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }

    protected virtual void Update() { }
    public virtual void Fire() { }
    public virtual void LevelUp() { }
}
