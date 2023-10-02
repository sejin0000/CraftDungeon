using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour // 인벤토리 혹은 도감. 아이템을 만들곳에 붙이기
{
 //   public Item[] selectItems = new Item[2]; // -> 도감에서 아이템 슬롯을 누르면 selectItem으로 정보를 넘겨줌 / Item은 bool isCraft변수를 가짐 - 던전이 클리어되면 false로 초기화
    
    void SelectItem() // 도감에서 아이템 슬롯을 누르면 실행
    {

    }

    void Crafting() // 도감에서 아이템 조합을 누르면 실행
    {
  //      foreach(Item i in selectItems) // 두개의 아이템을 선택 후 Craft버튼을 눌러야만 실행되도록 함.
  //      {
  //          if (i == null) return;
  //      }
        // Craft UI를 켜준다.(조합 장면, 조합결과)



//        if(!selectItem.itemData.isCraft) // 만든적 없으면 경험치를 줌
        {
//            GameManager.instance.player.curExp += selectItem.itemData.itemExp; // 플레이어의 현재 경험치에 아이템이 가진 경험치만큼 더해줌
            // 아이템은 스크립터블 오브젝트로 생성할 예정이니 ItemData가 해당 아이템의 경험치를 가지고 있는 방식으로 구현
        }

        // 1. 만드려는 아이템을 검색(도감에서 검색) -> 검색할 필요 없이 도감에서 선택한 아이템을 가져오기
        // 2. 만드려는 아이템을 만든적이 있는가? -> 아이템이 가지고 있는 isCraft변수 참조
        // 3. 만든적이 없다면 "아이템 티어"에 따라 플레이어가 경험치를 획득 -> 아이템 티어를 만들지 않아도 아이템 별 경험치를 스크립터블 오브젝트로 지정해줄수 있음
    }

}
