using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonPattern<GameManager>
{
    public GameObject platformPrefab;
    public GameObject enemyPrefab;
    public Transform platformSpawner;
    public Transform[] enemySpawners;

    public float floorSpawnTime;
    public float enemySpawnTime;
    public List<string> availableCommands = new List<string>();
    void Start()
    {
        StartCoroutine("PlatformSpawnRoutine");
        StartCoroutine("SpawnEnemyRoutine");
    }

    IEnumerator PlatformSpawnRoutine()
    {
        while (true)
        {
            Instantiate(platformPrefab, platformSpawner.position, platformSpawner.rotation, platformSpawner);
            yield return new WaitForSeconds(floorSpawnTime);
        }
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            Transform s = enemySpawners[Random.Range(0, enemySpawners.Length - 1)];
            Instantiate(enemyPrefab, s.position, s.rotation, s.parent);
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
