using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public PlayerController player;
    public List<Transform> patrolPoints;

    public int enemiesMaxCount = 6;
    public float delay = 4;
    public float IncreaseEnemiesCountdelay = 30;


    public List<Transform> spawnerPoints;
    private List<EnemyAI> _enemies;

    private float _TimeLastSpawned;

    private void Start()
    {
        _enemies = new List<EnemyAI>();
        Invoke("IncreaseEnemiesMaxCount", IncreaseEnemiesCountdelay);
    }

    private void IncreaseEnemiesMaxCount()
    {
        enemiesMaxCount++;
        Invoke("IncreaseEnemiesMaxCount", IncreaseEnemiesCountdelay);
    }



    private void Update()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }

        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _TimeLastSpawned < delay) return;
        CreateEnemy();
    }



    private void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = spawnerPoints[Random.Range(0, spawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _TimeLastSpawned = Time.time;
    }
}
