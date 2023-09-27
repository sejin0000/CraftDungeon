using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject UI;
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    public GameObject InfoPanel;


    void Start()
    {
        UI.SetActive(false);
    }

    public void OpenUi()
    {
        if (UI.activeSelf == true)
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    public void Button1()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
    }

    public void Button2()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel3.SetActive(false);
    }

    public void Button3()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
    }

    public void OpenInfo(ItemSO item)
    {
        InfoPanel.SetActive(true);
        GetComponent<UIItemInfo>().DrawInfo(item);
    }
    public void CloseInfo()
    {
        InfoPanel.SetActive(false);
    }
}
