using UnityEngine;

public class MaxHealthItem : PassiveItemBase
{
    [SerializeField] private int maxHealth;
    public override void OnAdd(PlayerStats player)
    {
        if(!IsDebuf)
        {
            player.AddMaxHealth(maxHealth);
        }
        else
        {
            player.RemoveMaxHealth(maxHealth);
        }
    }

    public override void OnRemove(PlayerStats player)
    {
        //Nothing
    }
}
