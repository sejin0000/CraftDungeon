using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    private static GameUIManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        InvenPanel.SetActive(false);
    }

    public static GameUIManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public GameObject infoPanel;
    public GameObject InvenPanel;
    public Canvas canvas;

    public void OpenCloseInventory()
    {

        if (InvenPanel.activeSelf)
        {
            InvenPanel.SetActive(false);
        }
        else
        {
            InvenPanel.SetActive(true);
        }
    }
}
