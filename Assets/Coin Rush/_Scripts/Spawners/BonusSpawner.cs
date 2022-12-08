using CoinRush.Abstracts;
using CoinRush.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour, ISpawner
{
    [Serializable]
    private struct BonusSpawnSettings
    {
        public string bonusType;
        public Bonus bonusPrefab;
        [Range(0, 100)] public int spawnChance;
    }
    [Header(" SETTINGS ")]
    [SerializeField] List<BonusSpawnSettings> spawnSettings;

    [Header(" ELEMETS ")]
    [SerializeField] List<Transform> spawnPoints;

    private void Start()
    {
        Spawn();
    }

    [ContextMenu("Spawn Bonuses")]
    public void Spawn()
    {
        for (int i = 0; i < spawnSettings.Count; i++)
        {
            if (spawnPoints.Count == 0) break;
            for (int j = 0; j < spawnPoints.Count; j++)
            {          
                if (CanSpawn(spawnSettings[i].spawnChance))
                {
                    var spawnPoint = RandomSpawnPoint();
                    Instantiate(spawnSettings[i].bonusPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
                }   
            }
        }
    }
    private bool CanSpawn(int spawnChance) => UnityEngine.Random.Range(0, 100) < spawnChance;
    private Transform RandomSpawnPoint()
    {
        var randomIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
        var spawnPoint = spawnPoints[randomIndex];
        spawnPoints.Remove(spawnPoint);
        return spawnPoint;
    }
}
