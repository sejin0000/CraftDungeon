using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBox : MonoBehaviour
{
    private bool _isOpen = false;
    private bool _isOpenable = false;

    public GameObject notOpenedbox;
    public GameObject openedBox;

    private void OpenBox()
    {
        if (_isOpen)
            return;

        _isOpen = true;
        openedBox.SetActive(true);
        notOpenedbox.SetActive(false);

        GetReward();
    }

    private void GetReward()
    {

    }

    private void Update()
    {
        if (_isOpenable)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                OpenBox();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isOpenable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isOpenable = false;
        }
    }

}
