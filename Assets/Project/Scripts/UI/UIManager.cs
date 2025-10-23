using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TimerUI timerUI;
    [SerializeField] private ExpHolderUI expHolderUI;
    [SerializeField] private PauseMenuUI pauseMenuUI;

    private void Start()
    {
        PauseSystem.Instance.PauseChanged += OnPauseChange;
    }

    private void OnPauseChange(bool isPaused)
    {
        if(isPaused)
        {
            pauseMenuUI.gameObject.SetActive(true);
        }
        else
        {
            pauseMenuUI.gameObject.SetActive(false);
        }
    }
}
