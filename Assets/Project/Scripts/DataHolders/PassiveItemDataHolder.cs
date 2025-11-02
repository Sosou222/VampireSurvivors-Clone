using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PassiveItemDataHolder : Singleton<PassiveItemDataHolder>
{
    [SerializeReference]private List<PassiveItemBase> items = new();

    public List<PassiveItemBase> GetItems()
    {
        return items;
    }

    public List<PassiveItemBase> GetItemsBuffs()
    {
        return items.Where(item => item.IsDebuf == false).ToList();
    }

    public List<PassiveItemBase> GetItemsDebuf()
    {
        return items.Where(item => item.IsDebuf == true).ToList();
    }
}
