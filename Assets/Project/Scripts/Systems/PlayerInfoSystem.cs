using UnityEngine;

public class PlayerInfoSystem : Singleton<PlayerInfoSystem>
{
    private Player player = null;

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public Vector3 GetPosition()
    {
        if (player == null)
        {
            return Vector3.zero;
        }
        else
        {
            return player.gameObject.transform.position;
        }
    }
}
