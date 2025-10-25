using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : PersistentSingleton<InputManager>
{
    private PlayerInput playerInput;
    private Vector2 lastMousePos;

    protected override void Awake()
    {
        base.Awake();
        playerInput = new();
        playerInput.Player.Enable();
        playerInput.UI.Disable();
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
            Instance.playerInput.UI.Disable();
        }
        else
        {
            Instance.playerInput.Player.Disable();
            Instance.playerInput.UI.Enable();
        }
    }

    public static Vector2 GetMouseScreenPosition()
    {
        if(Instance.playerInput.Player.enabled)
        {
            Instance.lastMousePos = Mouse.current.position.ReadValue();
        }
        return Instance.lastMousePos;
    }

    public static bool IsMouseButtonDownThisFrame()
    {
        if (!Instance.playerInput.Player.enabled)
        {
            return false;
        }
        return Mouse.current.leftButton.wasPressedThisFrame;
    }
    public static bool IsMouseButtonDown()
    {
        if (!Instance.playerInput.Player.enabled)
        {
            return false;
        }
        return Mouse.current.leftButton.isPressed;
    }

    public static Vector2 GetPlayerMove()
    {
        return Instance.playerInput.Player.Move.ReadValue<Vector2>();
    }

    public static bool GetPauseToggle()
    {
        if(Instance.playerInput.Player.enabled)
        {
            return Instance.playerInput.Player.MenuOpen.WasPressedThisFrame();
        }
        if(Instance.playerInput.UI.enabled)
        {
            return Instance.playerInput.UI.MenuClose.WasPressedThisFrame();
        }
        return false;
    }

    public static Vector2 GetNavigationVector()
    {
        return Instance.playerInput.UI.Navigate.ReadValue<Vector2>();
    }
}
