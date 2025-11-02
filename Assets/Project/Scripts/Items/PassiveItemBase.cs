using UnityEngine;

[System.Serializable]
public abstract class PassiveItemBase 
{
    [field:SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public bool IsDebuf { get; private set; }
    public abstract void OnAdd(PlayerStats player);
    public abstract void OnRemove(PlayerStats player);
}
