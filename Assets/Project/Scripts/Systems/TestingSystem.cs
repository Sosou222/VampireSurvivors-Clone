using UnityEngine;

public class TestingSystem : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(!PauseSystem.Instance.IsPaused)
            {
                PauseSystem.Instance.Pause();
            }
            else
            {
                PauseSystem.Instance.UnPause();
            }
        }
    }
}
