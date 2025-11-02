using System;
using UnityEngine;

[Serializable]
public class HealingPickUpBehaviour : IPickUpBehaviour
{
    [SerializeField] private int healAmount = 5;
    public void OnPickUp(Player player)
    {
        player.Heal(healAmount);
    }
}
