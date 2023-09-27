using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] Slider slExp;
    [SerializeField] TextMeshProUGUI EXP_num;
    TMP_Text numText;

    // GameManager gameManager         // 게임매니저로부터 현재 플레이어의 레벨과 경험치 가져오기
    [SerializeField] int curExp;       
    [SerializeField] int ExpEarned;


    // test 용 경험치 표, 레벨
    private int maxExp;               // 해당 레벨의 최대 경험치
    [SerializeField] int[] ExpTable = new int[] {10, 20, 60, 120, 300};
    [SerializeField] int level;
    private int[] currentExpArray;
    private int[] calculateExpArray;
    private int ExpApplied;

    bool isApply = false;
    void Start()
    {
        slExp = GetComponent<Slider>();
        numText = EXP_num.GetComponent<TextMeshProUGUI>();
        maxExp = ExpTable[level - 1];
        slExp.value = (float)curExp / (float)maxExp;
        // 현재 경험치 정보 반영
        EXP_num.GetComponent<TextMeshProUGUI>().text = $"{curExp.ToString()}/{maxExp.ToString()}";
        currentExpArray = new int[] { curExp, maxExp, level };
        calculateExpArray = CalculateExp(curExp, ExpEarned, maxExp, level);
    }

    // Update is called once per frame
    void Update()
    {
        while (!isApply && ExpApplied < ExpEarned)
        {
            ExpApplied += 1;
            isApply = true;
            if (curExp + 1 >= maxExp)
            {
                curExp = 0;
                level += 1;
                maxExp = ExpTable[level - 1];
            }
            else
            {
                curExp += 1;
            }
            UpdateExp();
            StartCoroutine(ApplyExp());
        }
    }

    private void UpdateExp()
    {
        slExp.value = (float)curExp / (float)maxExp;
        EXP_num.GetComponent<TextMeshProUGUI>().text = $"{curExp.ToString()}/{maxExp.ToString()}";
        currentExpArray = new int[] { curExp, maxExp, level };
        calculateExpArray = CalculateExp(curExp, ExpEarned, maxExp, level);
    }

    private int[] CalculateExp(int currentExp, int expEarned, int maxExp, int level)
    {
        while (currentExp + expEarned > maxExp )
        {
            expEarned = currentExp + expEarned - maxExp;
            level += 1;
            currentExp = 0;
            if (level > ExpTable.Length)
            {
                currentExp = 9999;
                maxExp = 9999;
            }
            maxExp = ExpTable[level - 1];
        }
        int[] calculatedExpArray = new int[] { currentExp, maxExp, level };
        return calculatedExpArray;
    }

    IEnumerator ApplyExp()
    {
        float interval = (1 / ExpEarned);
        yield return new WaitForSeconds(interval);
        isApply = false;
    }
}
