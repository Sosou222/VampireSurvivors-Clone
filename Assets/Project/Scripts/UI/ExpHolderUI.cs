using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpHolderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Slider slider;

    private void Start()
    {
        ExpierienceSystem.Instance.ExpChanged += OnExpChange;
        OnExpChange();
    }

    private void OnExpChange()
    {
        int left = ExpierienceSystem.Instance.CurrentExp;
        int right = ExpierienceSystem.Instance.ExpToNextLv;

        slider.value = ExpierienceSystem.Instance.Normalize();
        text.text = left +"/" + right;
    }
}
