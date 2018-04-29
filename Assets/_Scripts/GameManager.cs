using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonPattern<GameManager>
{
    public GameObject platformPrefab;
    public GameObject enemyPrefab;
	public GameObject bossPrefab;

	public GameObject[] itemPrefabs;

    public Transform platformSpawner;
    public Transform[] enemySpawners;

    public float floorSpawnTime;
    public float enemySpawnTime;
    public List<string> availableCommands = new List<string>();

	public int enemyCount = 0;
    void Start()
    {
        StartCoroutine("PlatformSpawnRoutine");
        StartCoroutine("SpawnEnemyRoutine");
		StartCoroutine("SpawnItemsRoutine");
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
			Vector3 offset = new Vector3(0,80f,0);
            Instantiate(enemyPrefab, s.position, s.rotation, s.parent);
			if (++enemyCount % 15 == 0) {
				Instantiate (bossPrefab, platformSpawner.position + offset, platformSpawner.rotation, platformSpawner);
			}
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

	IEnumerator SpawnItemsRoutine()
	{
		while (true)
		{
			Vector3 offset = new Vector3 (0,70f,0);
			Instantiate(itemPrefabs[Random.Range(0,itemPrefabs.Length-1)], platformSpawner.position + offset, platformSpawner.rotation, platformSpawner);
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
