using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void Setup(HealthComponent healthComponent)
    {
        OnInfoChanged(healthComponent);

        healthComponent.InfoChanged += OnInfoChanged;
    }

    private void OnInfoChanged(HealthComponent healthComponent)
    {
        slider.value = healthComponent.Normalize();
    }
}
