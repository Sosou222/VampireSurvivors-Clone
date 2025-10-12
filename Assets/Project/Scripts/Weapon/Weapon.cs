using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected WeaponData weaponData;
    public int Level { get; private set; } = 1;
    public int MaxLevel => weaponData.MaxLevel;
    public bool UsesKeyToFire => weaponData.UsesKeyToFire;
    public int Damage => weaponData.Damage[Level - 1];
    protected float cooldown => weaponData.CoolDown[Level - 1];

    public void Setup(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }

    protected virtual void Update() { }
    public virtual void Fire() { }
    public void LevelUp() {
        if(Level < MaxLevel)
        {
            Level++;
            OnLevelUp();
        }
    }

    protected virtual void OnLevelUp() { }
}
