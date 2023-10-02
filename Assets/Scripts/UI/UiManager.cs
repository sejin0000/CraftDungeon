using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject infoPanel;
    public GameObject InvenPanel;
    public Canvas canvas;

    private void Awake()
    {
        Instance = this;
        InvenPanel.SetActive(false);
    }

    public static UIManager instance
    {
        get
        {
            return Instance;
        }
    }
    private Stack<UIPopup> popups = new Stack<UIPopup>();

    private UIPopup ShowPopup(string popupname)
    {
        GameObject obj = Resources.Load("Popups/" + popupname, typeof(GameObject)) as GameObject;
        if (!obj)
        {
            return null;
        }
        return ShowPopupWithPrefab(obj, popupname);
    }

    public T ShowPopup<T>() where T : UIPopup
    {
        return ShowPopup(typeof(T).Name) as T;
    }

    public UIPopup ShowPopupWithPrefab(GameObject prefab, string popupName)
    {
        GameObject obj = Instantiate(prefab);
        return ShowPopup(obj, popupName);
    }

    public UIPopup ShowPopup(GameObject obj, string popupname)
    {
        UIPopup popup = obj.GetComponent<UIPopup>();
        popups.Push(popup);

        obj.SetActive(true);

        return popup;
    }

    public void ClosAllPopup()
    {
        while (popups.Count > 0)
        {
            Destroy(popups.Pop().gameObject);
        }
    }

    public void ClosePopup()
    {
        Destroy(popups.Pop().gameObject);
    }

    public UIPopup GetPopup()
    {
        return popups.Peek();
    }

    public void OpemCloseInventory()
    {

        if(InvenPanel.activeSelf)
        {
            InvenPanel.SetActive(false);
        }
        else
        {
            InvenPanel.SetActive(true);
        }
    }
}
