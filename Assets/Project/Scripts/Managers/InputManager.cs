using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : Singleton<InputManager>
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

    public static Vector2 GetMouseScreenPosition()
    {
        return Mouse.current.position.ReadValue();
    }

    public static bool IsMouseButtonDown()
    {
        return Mouse.current.leftButton.wasPressedThisFrame;
    }

    public static Vector2 GetPlayerInput()
    {
        return Instance.playerInput.Player.Move.ReadValue<Vector2>();
    }
}
