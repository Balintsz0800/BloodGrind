using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public float minSpawnDistance = 8f;
    public float maxSpawnDistance = 14f;

    public float spawnIntervalMinStart = 0.5f;
    public float spawnIntervalMaxStart = 1.2f;

    public float timeToMaxDifficulty = 300f;
    public float spawnIntervalMinFinal = 0.15f;
    public float spawnIntervalMaxFinal = 0.5f;

    public int maxEnemiesOnScreen = 60;

    private Transform player;
    private float timer;
    private float currentIntervalMin;
    private float currentIntervalMax;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        currentIntervalMin = spawnIntervalMinStart;
        currentIntervalMax = spawnIntervalMaxStart;
        timer = Random.Range(currentIntervalMin, currentIntervalMax);
    }

    void Update()
    {
        float t = Mathf.Clamp01(Time.time / timeToMaxDifficulty);
        currentIntervalMin = Mathf.Lerp(spawnIntervalMinStart, spawnIntervalMinFinal, t);
        currentIntervalMax = Mathf.Lerp(spawnIntervalMaxStart, spawnIntervalMaxFinal, t);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemiesOnScreen)
            {
                SpawnOneEnemy();
            }
            timer = Random.Range(currentIntervalMin, currentIntervalMax);
        }
    }

    void SpawnOneEnemy()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector2 spawnPos = (Vector2)player.position + randomDir * distance;

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}