using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool _isAvailable = false;

    private void Update()
    {
        if (_isAvailable)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                OpenShop();
            }
        }
    }
    private void OpenShop()
    {
        if (UIManager.Instance.GetPopup() != null)
        {
            if (UIManager.Instance.GetPopup().GetType() == typeof(UIShop))
                return;
        }

        UIShop shopPopup = UIManager.Instance.ShowPopup<UIShop>();
        shopPopup.transform.SetParent(GameManager.Instance.gameUICanvasTrans, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isAvailable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isAvailable = false;
        }
    }
}
