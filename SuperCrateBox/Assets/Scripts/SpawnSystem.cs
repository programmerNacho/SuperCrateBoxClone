using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [System.Serializable]
    public class HordeInfo
    {
        public GameObject hordePrefab;
    }

    public List<HordeInfo> hordes;
    public List<Transform> spawnPoints;
    public float startTime;
    public float timeToSpawn;

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", startTime, timeToSpawn);
    }

    private void SpawnEnemies()
    {
        HordeInfo horde = hordes[Random.Range(0, hordes.Count)];
        GameObject hordeCreated = Instantiate(horde.hordePrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
        GroundEnemy[] enemiesInHorde = hordeCreated.GetComponentsInChildren<GroundEnemy>();

        if (hordeCreated.transform.localPosition.x < 0)
        {
            InitializeEnemies(enemiesInHorde, 1, false);
        }

        else
        {
            InitializeEnemies(enemiesInHorde, -1, false);
        }
    }

    private void InitializeEnemies(GroundEnemy[] enemiesInHorde, int directionX, bool flipped)
    {
        foreach (GroundEnemy item in enemiesInHorde)
        {
            item.InitializeEnemy(directionX, flipped);
        }
    }
}
