using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDictionary : MonoBehaviour
{
    [SerializeField] private GameObject Content;
    RectTransform _scrollRect;
    GameObject ItemPrefab;
    // GameManager gameManager;                     // ���� �Ŵ������� �ش� �÷��̵��� ���� ���� ������
    GameObject[] ObtainedArray;                     // ������ �� ������ ���
    private void Start()
    {
        _scrollRect = Content.GetComponent<RectTransform>();
        // ������ �迭�� ���ӸŴ������� ä�� �迭�� ä��.
        // ObtainedArray = ~~~~;
        // ControllWidth();
    }

    private void ControllWidth()
    {
        var width = _scrollRect.sizeDelta.x;
        var height = _scrollRect.sizeDelta.y;
        int calculatedWidth = 50 * ObtainedArray.Length + 100;
        _scrollRect.sizeDelta = new Vector2(calculatedWidth, height);
    }

    private void AttachItem()
    {
        for (int i = 0; i < ObtainedArray.Length; i++)
        {
            // ObtainedArray�� ��������Ʈ Prefab�� ����
            ItemPrefab.GetComponent<SpriteRenderer>().sprite = ObtainedArray[i].GetComponent<SpriteRenderer>().sprite;
            // ��Ÿ �Ӽ� ����.
            Instantiate(ItemPrefab);
        }
    }
}
