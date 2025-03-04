using System.Collections.Generic;
using UnityEngine;
using TMPro; // ✅ Required for TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Enemy Spawning")]
    public GameObject fastEnemyPrefab;
    public GameObject strongEnemyPrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 2f;
    public int maxEnemies = 10;

    [Header("Game Over UI")]
    public GameObject gameOverText; 

    private float spawnTimer = 0f;
    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        activeEnemies.RemoveAll(enemy => enemy == null);

        if (spawnTimer >= spawnRate && activeEnemies.Count < maxEnemies)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints == null || spawnPoints.Length == 0) return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        if (fastEnemyPrefab == null || strongEnemyPrefab == null) return;

        GameObject enemyToSpawn = Random.Range(0, 2) == 0 ? fastEnemyPrefab : strongEnemyPrefab;
        if (enemyToSpawn == null) return;

        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPoints[spawnIndex].position, Quaternion.identity);
        activeEnemies.Add(newEnemy);
    }

    public void EnemyDied(GameObject enemy)
    {
        if (enemy != null)
        {
            activeEnemies.Remove(enemy);
        }
    }

    public int GetEnemyCount() => activeEnemies.Count;

    public void GameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }
}
