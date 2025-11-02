using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Button unpauseButton;

    private void Start()
    {
        unpauseButton.onClick.AddListener(PauseSystem.Instance.UnPause);
        unpauseButton.onClick.AddListener(() => gameObject.SetActive(false));
    }
}
