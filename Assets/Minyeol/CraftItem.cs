using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour // �κ��丮 Ȥ�� ����. �������� ������� ���̱�
{
 //   public Item[] selectItems = new Item[2]; // -> �������� ������ ������ ������ selectItem���� ������ �Ѱ��� / Item�� bool isCraft������ ���� - ������ Ŭ����Ǹ� false�� �ʱ�ȭ
    
    void SelectItem() // �������� ������ ������ ������ ����
    {

    }

    void Crafting() // �������� ������ ������ ������ ����
    {
  //      foreach(Item i in selectItems) // �ΰ��� �������� ���� �� Craft��ư�� �����߸� ����ǵ��� ��.
  //      {
  //          if (i == null) return;
  //      }
        // Craft UI�� ���ش�.(���� ���, ���հ��)



//        if(!selectItem.itemData.isCraft) // ������ ������ ����ġ�� ��
        {
//            GameManager.instance.player.curExp += selectItem.itemData.itemExp; // �÷��̾��� ���� ����ġ�� �������� ���� ����ġ��ŭ ������
            // �������� ��ũ���ͺ� ������Ʈ�� ������ �����̴� ItemData�� �ش� �������� ����ġ�� ������ �ִ� ������� ����
        }

        // 1. ������� �������� �˻�(�������� �˻�) -> �˻��� �ʿ� ���� �������� ������ �������� ��������
        // 2. ������� �������� �������� �ִ°�? -> �������� ������ �ִ� isCraft���� ����
        // 3. �������� ���ٸ� "������ Ƽ��"�� ���� �÷��̾ ����ġ�� ȹ�� -> ������ Ƽ� ������ �ʾƵ� ������ �� ����ġ�� ��ũ���ͺ� ������Ʈ�� �������ټ� ����
    }

}
