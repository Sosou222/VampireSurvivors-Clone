using UnityEngine;

public class TargetPointStatic : ITargetPoint
{
    private Vector3 point;

    public TargetPointStatic()
    {
        point = PlayerInfoSystem.Instance.GetPosition();
    }

    public void SetPoint(Vector3 point)
    { 
        this.point = point; 
    }

    public Vector3 GetTargetPoint()
    {
        return point;
    }

}
