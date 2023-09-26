using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyType { Skeleton, Zombie, Golem }

public class EnemySpawner : MonoBehaviour // 에너미 스포너에 붙이기
{
    [SerializeField] 
    private List<EnemyData> enemyDatas;
    [SerializeField] 
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform[] spawnPoint;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        for(int i = 0; i < enemyDatas.Count; i++)
        {
            Enemy enemy = SpawnEnemy((EnemyType)i);
        }    
    }

    public Enemy SpawnEnemy(EnemyType type)
    {
        Enemy newEnemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
        newEnemy.enemyData = enemyDatas[(int)type];
        newEnemy.name = newEnemy.enemyData.EnemyName;
        //newEnemy.GetComponent<Image>().sprite = newEnemy.enemyData.EnemySprite;
        newEnemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;

        return newEnemy;
    }
}
