using UnityEngine;

public class PauseSystem : Singleton<PauseSystem>
{
    public bool IsPaused { get; private set; } = false;

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0;

        InputManager.SetPlayerInputStatus(false);
    }

    public void UnPause()
    {
        IsPaused = false;
        Time.timeScale = 1;

        InputManager.SetPlayerInputStatus(true);
    }
}
