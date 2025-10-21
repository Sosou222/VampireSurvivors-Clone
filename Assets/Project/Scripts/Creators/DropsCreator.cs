using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class DropsCreator : SerializedSingleton<DropsCreator>
{
    [OdinSerialize] private Dictionary<DropItemType, GameObject> dropsPrefabs = new();

    public GameObject Create(DropItemType type)
    {
        if(dropsPrefabs.ContainsKey(type))
        {
            GameObject drop = Instantiate(dropsPrefabs[type]);
            return drop;
        }

        Debug.LogWarning(type.ToString() + " has no prfab assigned");
        return null;
    }
}

public enum DropItemType
{
    ExpierienceGemSmall
}