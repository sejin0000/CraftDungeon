using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusHandler : MonoBehaviour
{
    [SerializeField] private Characterstatus baseStats;
    public Characterstatus CurrentStats { get; private set; }
    public List<Characterstatus> statsModifiers = new List<Characterstatus>();

    private void Awake()
    {
        UpdateCharacterStatus();
    }

    private void UpdateCharacterStatus()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null) 
        {
            attackSO = Instantiate(baseStats.attackSO); // baseStats�� �ɷ��ִ� �ָ� �������� ���� : �����ο� ������ ���ؼ�
        }

        CurrentStats = new Characterstatus { attackSO = attackSO };

        // �ӽ�
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;

    }

}
