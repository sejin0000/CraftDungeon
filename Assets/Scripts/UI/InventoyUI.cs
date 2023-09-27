using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoyUI : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    public void OpenPage1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
    }
    public void OpenPage2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page3.SetActive(false);
    }
    public void OpenPage3()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);
    }
}
