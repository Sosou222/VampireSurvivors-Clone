using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    void Update()
    {
        Vector3 playerPos = PlayerInfoSystem.Instance.GetPosition();
        transform.position = new Vector3(playerPos.x,playerPos.y,transform.position.z);
    }
}
