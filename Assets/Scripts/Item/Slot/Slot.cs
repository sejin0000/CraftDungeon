using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemSO curItem;
    public Image icon;

    private void Start()
    {
        icon.sprite = curItem.sprite;
    }

    public void OpenInfo()
    {
        UiManager.instance.infoPanel.GetComponent<InfoPanel>().OpenInfo(this);
    }
}
