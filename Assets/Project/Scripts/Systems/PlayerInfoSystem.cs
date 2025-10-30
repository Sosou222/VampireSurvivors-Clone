using UnityEngine;

public class PlayerInfoSystem : Singleton<PlayerInfoSystem>
{
    private Player player = null;
    private Vector3 lastPlayerPosition = Vector3.zero;

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public Vector3 GetPosition()
    {
        if (player != null)
        {
            lastPlayerPosition = player.gameObject.transform.position;
        }
        return lastPlayerPosition;
    }

    public bool TryGetPlayer(out Player Player)
    {
        if (player != null)
        {
            Player = player;
            return true;
        }
        Player = null; 
        return false;
    }
}
