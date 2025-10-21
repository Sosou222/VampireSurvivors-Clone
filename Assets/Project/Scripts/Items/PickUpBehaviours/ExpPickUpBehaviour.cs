using System;
using UnityEngine;

[Serializable]
public class ExpPickUpBehaviour : IPickUpBehaviour
{
    [SerializeField] private int exp;
    public void OnPickUp(Player player)
    {
        ExpierienceSystem.Instance.AddExp(exp);
    }
}
