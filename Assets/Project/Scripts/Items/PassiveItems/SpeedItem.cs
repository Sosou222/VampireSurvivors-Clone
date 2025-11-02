using UnityEngine;

[System.Serializable]
public class SpeedItem : PassiveItemBase
{
    [SerializeField] private float speedMult;

    public override void OnAdd(PlayerStats player)
    {
        player.AddSpeedMult(speedMult);
    }

    public override void OnRemove(PlayerStats player)
    {
        player.RemoveSpeedMult(speedMult);
    }
}
