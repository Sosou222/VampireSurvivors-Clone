using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TimerUI timerUI;
    [SerializeField] private ExpHolderUI expHolderUI;
    [SerializeField] private PauseMenuUI pauseMenuUI;
    [SerializeField] private CardSelectionManagerUI cardSelectionManagerUI;

    private bool isShowingUpgrades = false;

    private void Update()
    {
        if(!isShowingUpgrades)
        {
            return;
        }

        if (InputManager.GetPauseToggle())
        {
            if (PauseSystem.Instance.IsPaused)
            {
                PauseSystem.Instance.UnPause();
                OnPauseChange(false);
            }
            else
            {
                PauseSystem.Instance.Pause();
                OnPauseChange(true);
            }
        }
    }

    public void ShowUpgrades(List<UpgradeCardInfo> infoList)
    {
        isShowingUpgrades = true;
        PauseSystem.Instance.Pause();
        cardSelectionManagerUI.ShowUpgrades(infoList, OnStopShowingUpgrades);
    }

    private void OnStopShowingUpgrades()
    {
        isShowingUpgrades = false;
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
