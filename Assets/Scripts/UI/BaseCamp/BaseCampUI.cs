using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCampUI : MonoBehaviour
{
    public Transform uiCanvasTrans;

    public Button optionBtn;

    private void Start()
    {
        optionBtn.onClick.AddListener(OptionBtnClicked);
    }

    private void OptionBtnClicked()
    {
        UIOption optionPopup = UIManager.Instance.ShowPopup<UIOption>();
        optionPopup.transform.SetParent(uiCanvasTrans, false);
    }
}
