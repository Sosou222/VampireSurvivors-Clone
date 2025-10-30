using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelectionManagerUI : MonoBehaviour
{
    [field :SerializeField]public List<UpgradeCardUI> Cards {get; private set;}
    
    public GameObject LastSelected {  get; private set; }
    public int LastSelectedIndex { get; private set; }

    private void Start()
    {
        foreach (var card in Cards)
        {
            card.Setup(this);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(SetSelectedAfterOneFrame());
    }

    private void Update()
    {
        if(InputManager.GetNavigationVector().x > 0)
        {
            HandleNextCardSelection(1);
        }
        if (InputManager.GetNavigationVector().x < 0)
        {
            HandleNextCardSelection(-1);
        }
    }

    public void ShowUpgrades(List<UpgradeCardInfo> infoList,Action onStopShowingUpgrades)
    {
        for (int i=0;i<Cards.Count;i++)
        {
            if (!(i + 1 > infoList.Count))
            {
                Cards[i].gameObject.SetActive(true);
                Cards[i].SetInfo(infoList[i], onStopShowingUpgrades);
            }
        }
    }

    public void Hide()
    {
        foreach(var card in Cards)
        {
            card.gameObject.SetActive(false);
        }
    }

    public void SetLastSelected(GameObject selected)
    {
        LastSelected = selected;
    }

    public void SetLastSelectedIndex(int index)
    {
        LastSelectedIndex = index;
    }
    private IEnumerator SetSelectedAfterOneFrame()
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(Cards[0].gameObject);
    }

    private void HandleNextCardSelection(int addition)
    {
        if(EventSystem.current.currentSelectedGameObject == null && LastSelected != null)
        {
            int newIndex = LastSelectedIndex + addition;
            newIndex = Mathf.Clamp(newIndex,0,Cards.Count-1);
            EventSystem.current.SetSelectedGameObject(Cards[newIndex].gameObject);
        }
    }
}
