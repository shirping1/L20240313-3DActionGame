using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemySlime;
    public GameObject enemyZombie;
    public float spawnTime = 3.0f;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        // InvokeRepeating("함수", 시간, 반복시간)
        // 해당 함수를 딜레이 시간 이후에 호출하고, 반복 시간을 주기로 해당 함수를 반복적으로 호출
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0.0f)
        {
            return;
        }

        int spawnPoolIndex = Random.Range(0, spawnPoints.Length); // 생성 지역의 개수만큼 랜덤한 수치의 값을 인덱스로 가져감

        int spawnRate = Random.Range(0, 100);


        if (spawnRate < 70)
        {
            Instantiate(enemySlime, spawnPoints[spawnPoolIndex].position, spawnPoints[spawnPoolIndex].rotation);
        }
        else
        {
            Instantiate(enemyZombie, spawnPoints[spawnPoolIndex].position, spawnPoints[spawnPoolIndex].rotation);
        }
    }
}
