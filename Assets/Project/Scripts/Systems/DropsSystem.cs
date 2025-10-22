using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class DropsSystem : Singleton<DropsSystem>
{
    public void Spawn(Vector3 position)
    {
        if(DropsCreator.Instance.TryCreate(out GameObject drop))
        {
            drop.transform.position = position;
        }
    }
}
