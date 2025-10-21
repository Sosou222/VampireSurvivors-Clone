using System;
using UnityEngine;

[Serializable]
public class ExpPickUpBehaviour : IPickUpBehaviour
{
    [SerializeField] private int exp;
    public void OnPickUp()
    {
        ExpierienceSystem.Instance.AddExp(exp);
    }
}
