using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : UIPopup
{
    private List<UIShopItem> _items = new List<UIShopItem>();

    public UIShopItem shopItemPrefab;
    public Transform itemContentTrans;

    public Button closeBtn;

    private void Start()
    {
        closeBtn.onClick.AddListener(CloseBtnClicked);
    }

    private void OnEnable()
    {
        AddShopItemUI();
    }

    private void OnDisable()
    {
        RemoveShopItemUI();
    }

    private void CloseBtnClicked()
    {
        UIManager.Instance.ClosePopup();
    }

    public void AddShopItemUI()
    {
        foreach(ItemSO data in GameManager.Instance.currentShopData.shopItems)
        {
            UIShopItem newItemUI = Instantiate(shopItemPrefab);
            newItemUI.SetItemData(data);
            newItemUI.transform.SetParent(itemContentTrans);

            _items.Add(newItemUI);
        }
    }

    public void RemoveShopItemUI()
    {
        foreach(UIShopItem item in _items)
        {
            Destroy(item.gameObject);
        }
    }
}
