using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOption : UIPopup
{
    public Button closeBtn;

    private void Start()
    {
        closeBtn.onClick.AddListener(OptionCloseBtnClicked);
    }

    private void OptionCloseBtnClicked()
    {
        UIManager.Instance.ClosePopup();
    }
}
