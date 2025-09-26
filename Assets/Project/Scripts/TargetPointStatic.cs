using UnityEngine;

public class TargetPointStatic : ITargetPoint
{
    private Vector3 point;

    public TargetPointStatic(Vector3 point)
    { 
        this.point = point; 
    }

    public Vector3 GetTargetPoint()
    {
        return point;
    }

}
