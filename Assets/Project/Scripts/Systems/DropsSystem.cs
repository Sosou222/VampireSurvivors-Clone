using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class DropsSystem : Singleton<DropsSystem>
{
    public void Spawn(Vector3 position,DropItemType type)
    {
        GameObject drop = DropsCreator.Instance.Create(type);
        drop.transform.position = position;
    }
}
