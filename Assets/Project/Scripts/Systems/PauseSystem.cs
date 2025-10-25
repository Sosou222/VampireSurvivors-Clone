using System;
using UnityEngine;

public class PauseSystem : Singleton<PauseSystem>
{
    public bool IsPaused { get; private set; } = false;
    public event Action<bool> PauseChanged;

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0;

        InputManager.SetPlayerInputStatus(false);

        PauseChanged?.Invoke(IsPaused);
    }

    public void UnPause()
    {
        IsPaused = false;
        Time.timeScale = 1;

        InputManager.SetPlayerInputStatus(true);

        PauseChanged?.Invoke(IsPaused);
    }
}
