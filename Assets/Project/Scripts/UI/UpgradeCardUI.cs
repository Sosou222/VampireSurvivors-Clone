using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeCardInfo
{
    public string TitleText;
    public string DescriptionText;
    public Action OnClickAction;

    public override string ToString()
    {
        return TitleText + ":" + DescriptionText;
    }
}

public class UpgradeCardUI : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,ISelectHandler,IDeselectHandler
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Button button;

    private Vector3 startPos;
    private Vector3 startScale;
    private CardSelectionManagerUI cardSelectionManager;

    private void Start()
    {
        startPos = transform.position;
        startScale = transform.localScale;
    }

    public void Setup(CardSelectionManagerUI cardSelectionManager)
    {
        this.cardSelectionManager = cardSelectionManager;
    }

    public void SetInfo(UpgradeCardInfo info, Action onStopShowingUpgrades)
    {
        title.text = info.TitleText;
        description.text = info.DescriptionText;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => 
        {
            info.OnClickAction();
            PauseSystem.Instance.UnPause();
            onStopShowingUpgrades();
            cardSelectionManager.Hide();
        });
    }

    private void MoveCard(bool focusOn)
    {
        float moveDuration = 0.2f;

        float verticalMoveAmount = 30.0f;
        float scaleAmount = 1.1f;


        Vector3 endPos;
        Vector3 endScale;

        if (focusOn)
        {
            endPos = startPos + new Vector3(0, verticalMoveAmount, 0);
            endScale = startScale * scaleAmount;
        }
        else
        {
            endPos = startPos;
            endScale = startScale;
        }

        Sequence tween = DOTween.Sequence();
        tween.Append(transform.DOMove(endPos,moveDuration));
        tween.Join(transform.DOScale(endScale,moveDuration));

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        MoveCard(true);

        for(int i=0;i<cardSelectionManager.Cards.Count;i++)
        {
            if (cardSelectionManager.Cards[i] == this)
            {
                cardSelectionManager.SetLastSelectedIndex(i);
                return;
            }
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        MoveCard(false);
    }
}
