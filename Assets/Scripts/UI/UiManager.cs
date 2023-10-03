using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;

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
    }

    public static UIManager Instance
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
        obj.name = popupName;
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
        if(popups.Count == 0)
        {
            return null;
        }
        else
            return popups.Peek();
    }
}
