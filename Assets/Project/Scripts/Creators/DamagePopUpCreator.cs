using UnityEngine;

public class DamagePopUpCreator : Singleton<DamagePopUpCreator>
{
    [SerializeField] DamagePopUp damagePopUpPrefab;
    public void CreatePopUp(Vector3 position,int damage)
    {
        DamagePopUp dmg = Instantiate(damagePopUpPrefab, position, Quaternion.identity);
        dmg.Setup(damage);
    }
}
