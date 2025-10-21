using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private bool disapearOnFullHP = false;
    public void Setup(HealthComponent healthComponent,bool disapearOnFullHP = false)
    {
        this.disapearOnFullHP = disapearOnFullHP;
        OnInfoChanged(healthComponent);

        healthComponent.InfoChanged += OnInfoChanged;
    }

    private void OnInfoChanged(HealthComponent healthComponent)
    {
        float hp = healthComponent.Normalize();
        slider.value = hp;
        if(disapearOnFullHP)
        {
            if(hp == 1.0f)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}
