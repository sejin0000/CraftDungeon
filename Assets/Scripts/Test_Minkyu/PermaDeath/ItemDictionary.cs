using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDictionary : MonoBehaviour
{
    [SerializeField] private GameObject Content;
    RectTransform _scrollRect;
    GameObject ItemPrefab;
    // GameManager gameManager;                     // 게임 매니저에서 해당 플레이동안 얻은 도감 가져옴
    GameObject[] ObtainedArray;                     // 도감의 각 아이템 목록
    private void Start()
    {
        _scrollRect = Content.GetComponent<RectTransform>();
        // 아이템 배열을 게임매니저에서 채운 배열로 채움.
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
            // ObtainedArray의 스프라이트 Prefab에 적용
            ItemPrefab.GetComponent<SpriteRenderer>().sprite = ObtainedArray[i].GetComponent<SpriteRenderer>().sprite;
            // 기타 속성 적용.
            Instantiate(ItemPrefab);
        }
    }
}
