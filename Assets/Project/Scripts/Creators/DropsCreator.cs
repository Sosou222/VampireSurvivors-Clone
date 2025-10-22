using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItem
{
    public string Name;
    public GameObject Prefab;
    public float DropRate;
}

public class DropsCreator : Singleton<DropsCreator>
{
    [SerializeField] private List<DropItem> dropItems = new();
    public bool TryCreate(out GameObject dropItem)
    {
        float rand = Random.Range(0.0f, 100.0f);
        List<DropItem> possibleDrops = new List<DropItem>();

        foreach(DropItem drop in dropItems)
        {
            if(rand <= drop.DropRate)
            {
                possibleDrops.Add(drop);
            }
        }

        if(possibleDrops.Count > 0)
        {
            DropItem drop = possibleDrops[Random.Range(0, possibleDrops.Count - 1)];
            dropItem = Instantiate(drop.Prefab);
            return true;
        }

        dropItem = null;
        return false;
    }
}