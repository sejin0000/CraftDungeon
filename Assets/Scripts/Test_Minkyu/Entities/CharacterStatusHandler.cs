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
            attackSO = Instantiate(baseStats.attackSO); // baseStats에 걸려있는 애를 가상으로 복제 : 자유로운 수정을 위해서
        }

        CurrentStats = new Characterstatus { attackSO = attackSO };

        // 임시
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;

    }

}
