using CoinRush.Abstracts;
using CoinRush.Enums;
using CoinRush.Helpers;
using CoinRush.Interfaces;
using CoinRush.Managers;
using System.Collections;
using UnityEngine;

public class AxeSpawner : MonoBehaviour, ISpawner
{
    [Header(" SETTINGS ")]
    [SerializeField][Range(1f, 3f)] private float minimumSpawnTime;
    [SerializeField][Range(3f, 10f)] private float maximumSpawnTime;
    
    [Header(" ELEMETS ")]
    [SerializeField] PoolableObject axePrefab;

    private ObjectPool _axePool;

    private void OnEnable() => GameManager.onGameStateChangedHandler += GameStateChangedCallback;
    private void OnDisable() => GameManager.onGameStateChangedHandler -= GameStateChangedCallback;

    private void Start()
    {
        _axePool = ObjectPool.CreateInstance(axePrefab, 20, this.transform, true);
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        if (gameState == GameState.Game) StartCoroutine(SpawnRoutine());
        else StopCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        var waitForSeconds = new WaitForSeconds(RandomSpawnTime());
        while (true)
        {
            Spawn();
            yield return waitForSeconds;
        }

    }
    private float RandomSpawnTime() => Random.Range(minimumSpawnTime, maximumSpawnTime);

    public void Spawn()
    {
        var axeFromPool = _axePool.GetObjectFromPool();
        axeFromPool.OnSpawn();
    }
}
