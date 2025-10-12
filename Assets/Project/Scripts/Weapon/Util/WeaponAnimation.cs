using DG.Tweening;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject objectToDestroy;
    void Start()
    {
        CreateTween();
    }

    private void CreateTween()
    {
        Color startColor = spriteRenderer.color;
        startColor.a = 0;
        spriteRenderer.color = startColor;

        float fadeDuration = 0.1f;
        float swingDuration = 1.0f;

        Sequence tween = DOTween.Sequence();
        tween.Append(spriteRenderer.DOFade(1.0f, fadeDuration));
        tween.Append(transform.DORotate(new Vector3(0, 0, -180), swingDuration).SetEase(Ease.OutQuad));
        tween.Append(spriteRenderer.DOFade(0.0f, fadeDuration));
        tween.onComplete += OnAnimationComplete;
    }

    private void OnAnimationComplete()
    {
        Destroy(objectToDestroy);
    }
}
