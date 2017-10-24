using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public static Spawner spawner;
    public string[] enemyPrefabNames;
    public bool spawn = true;
    Vector3 pos;
    public bool start = true;
    public float time = 3;

    public GameObject[] prefabs;

    private Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        if (spawner == null) spawner = this;
    }

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        prefabDict = new Dictionary<string, GameObject>();
        pools = new Dictionary<string, List<GameObject>>();

        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject prefab = prefabs[i];
            prefabDict[prefab.name] = prefab;
            pools[prefab.name] = new List<GameObject>();
        }
    }

    public static GameObject Spawn(string name, bool spawnActive = false)
    {
        GameObject spawn = null;

        List<GameObject> pool = spawner.pools[name];
        spawn = pool.Find((g) => !g.activeSelf);

        if (spawn == null)
        {
            spawn = Instantiate(spawner.prefabDict[name]);
            pool.Add(spawn);
        }

        spawn.SetActive(spawnActive);
        return spawn;
    }

    public IEnumerator SpawnEnemiesCoroutine()
    {
        while (spawn == true)
        {
            int spawnLocation = (Random.Range(0, 100) % 4);

            yield return new WaitForSeconds(time);

            string enemyPrefabName = enemyPrefabNames[Random.Range(0, enemyPrefabNames.Length)];

            GameObject enemy = Spawner.Spawn(enemyPrefabName);
            
            if (spawnLocation == 0)
            {
                pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(.1f, .9f), -Camera.main.transform.position.z));
            }
            if (spawnLocation == 1)
            {
                pos = Camera.main.ViewportToWorldPoint(new Vector3(-.1f, Random.Range(.1f, .9f), -Camera.main.transform.position.z));

            }
            if (spawnLocation == 2)
            {
                pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(.1f, .9f), 1.1f, -Camera.main.transform.position.z));

            }
            if (spawnLocation == 3)
            {
                pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(.1f, .9f), -.1f, -Camera.main.transform.position.z));

            }
            enemy.transform.position = pos;
            enemy.SetActive(true);
        }
    }

    public IEnumerator SubtractTime()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(20);
            time -= .25f;
        }
    }

    public IEnumerator StartSpawnEnemiesCoroutine()
    {
        while (start == true)
        {
            for (int i = 0; i < 3; i++)
            {
                int spawnLocation = (Random.Range(0, 100) % 4);

                yield return new WaitForSeconds(3f);

                string enemyPrefabName = enemyPrefabNames[i];

                GameObject enemy = Spawner.Spawn(enemyPrefabName);

                if (spawnLocation == 0)
                {
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(.1f, .9f), -Camera.main.transform.position.z));
                }
                if (spawnLocation == 1)
                {
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(-.1f, Random.Range(.1f, .9f), -Camera.main.transform.position.z));

                }
                if (spawnLocation == 2)
                {
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(.1f, .9f), 1.1f, -Camera.main.transform.position.z));

                }
                if (spawnLocation == 3)
                {
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(.1f, .9f), -.1f, -Camera.main.transform.position.z));

                }
                enemy.transform.position = pos;
                enemy.SetActive(true);
            }

            for (int i = 3; i < 6; i++)
            {
                int spawnLocation = (Random.Range(0, 100) % 4);

                yield return new WaitForSeconds(5f);

                string enemyPrefabName = enemyPrefabNames[i];

                GameObject enemy = Spawner.Spawn(enemyPrefabName);

                if (spawnLocation == 0)
                {
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(.1f, .9f), -Camera.main.transform.position.z));
                }
                if (spawnLocation == 1)
                {
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(-.1f, Random.Range(.1f, .9f), -Camera.main.transform.position.z));

                }
                if (spawnLocation == 2)
                {
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(.1f, .9f), 1.1f, -Camera.main.transform.position.z));

                }
                if (spawnLocation == 3)
                {
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(.1f, .9f), -.1f, -Camera.main.transform.position.z));

                }
                enemy.transform.position = pos;
                enemy.SetActive(true);
            }
            start = false;
        }

        StartCoroutine("SpawnEnemiesCoroutine");
    }
}
