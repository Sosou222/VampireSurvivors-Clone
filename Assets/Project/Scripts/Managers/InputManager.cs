using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : PersistentSingleton<InputManager>
{
    private PlayerInput playerInput;

    protected override void Awake()
    {
        base.Awake();
        playerInput = new();
        playerInput.Player.Enable();
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        playerInput.Player.Disable();
    }

    public static void SetPlayerInputStatus(bool isEnabled)
    {
        if(isEnabled)
        {
            Instance.playerInput.Player.Enable();
        }
        else
        {
            Instance.playerInput.Player.Disable();
        }
    }

    public static Vector2 GetMouseScreenPosition()
    {
        return Mouse.current.position.ReadValue();
    }

    public static bool IsMouseButtonDown()
    {
        return Mouse.current.leftButton.wasPressedThisFrame;
    }

    public static Vector2 GetPlayerMove()
    {
        return Instance.playerInput.Player.Move.ReadValue<Vector2>();
    }
}
