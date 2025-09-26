using UnityEngine;

public class TargetPointPlayer : ITargetPoint
{
    public Vector3 GetTargetPoint()
    {
        return PlayerInfoSystem.Instance.GetPosition();
    }
}
