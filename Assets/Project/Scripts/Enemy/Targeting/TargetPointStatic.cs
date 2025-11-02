using UnityEngine;

public class TargetPointStatic : ITargetPoint
{
    private Vector3 point = Vector3.zero;

    public void SetPoint(Vector3 point)
    {
        this.point = point; 
    }

    public Vector3 GetTargetPoint()
    {
        return point;
    }

}
