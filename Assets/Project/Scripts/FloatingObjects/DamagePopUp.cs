using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamagePopUp : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;

    public void Setup(int damage)
    {
        text.text = damage.ToString();
        CreateTween();
    }

    private void CreateTween()
    {
        Vector3 endMoveVal = new Vector3(0, 1, 0);
        float duration = 1.5f;

        Sequence tween = DOTween.Sequence();
        tween.Append(transform.DOMove(transform.position + endMoveVal, duration));
        tween.Join(text.DOFade(0, duration).SetEase(Ease.InOutCirc));
        tween.onComplete += OnDie;
    }

    private void OnDie()
    {
        Destroy(gameObject);
    }
}
