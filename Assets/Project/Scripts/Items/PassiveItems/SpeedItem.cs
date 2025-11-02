using UnityEngine;

[System.Serializable]
public class SpeedItem : PassiveItemBase
{
    [SerializeField] private float speedMult;

    public override void OnAdd(PlayerStats player)
    {
        if(!IsDebuf)
        {
            player.AddSpeedMult(speedMult);
        }
        else
        {
            player.RemoveSpeedMult(speedMult);
        }
    }

    public override void OnRemove(PlayerStats player)
    {
        if (!IsDebuf)
        {
            player.RemoveSpeedMult(speedMult);
        }
        else
        {
            player.AddSpeedMult(speedMult);
        }
    }
}
