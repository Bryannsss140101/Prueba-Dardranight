using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private Vector3 size;
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private float nextSpawn = 0.0f;
    [SerializeField] private int maxEnemies = 10;
    private int countEnemies;

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnEnemy();
        }
    }

    private void OnDrawGizmos()
    {
        if (!origin)
            return;

        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(origin.position, size);
    }

    private void SpawnEnemy()
    {
        float x = Random.Range(origin.position.x - size.x / 2, origin.position.x + size.x / 2);
        float y = Random.Range(origin.position.y - size.y / 2, origin.position.y + size.y / 2);
        Vector3 spawnPosition = new Vector3(x, y, -10);

        GameObject obj;
        float randomValue = Random.value;
        if (randomValue < 0.05)
            obj = ObjectPool.Instance.Get(ObjectType.EnemyBig);
        else if (randomValue < 0.20)
            obj = ObjectPool.Instance.Get(ObjectType.EnemyMedium);
        else if (randomValue < 0.80)
            obj = ObjectPool.Instance.Get(ObjectType.EnemySmall);
        else
            obj = ObjectPool.Instance.Get(ObjectType.Explotion);

        obj.transform.position = spawnPosition;

        countEnemies++;
    }
}