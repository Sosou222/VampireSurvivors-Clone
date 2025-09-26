using UnityEngine;

public class TestingSystem : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Mouse position:" +InputManager.GetMouseScreenPosition());
            Debug.Log("Move Vector:" + InputManager.GetPlayerInput());
        }
        if(InputManager.IsMouseButtonDown())
        {
            Debug.Log("Clicked");
        }
    }
}
