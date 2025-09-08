using UnityEngine;
using System.Collections;

public class RandomEnemy : MonoBehaviour
{
    public GameObject[] expPrefab; // 
    private float startDelay = 5f;
    private float spawnInterval = 10f;
    public float range = 15f;
    private int count = 0;
    private bool canSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy()
    {
        if ( canSpawn)
        {
            int enemyCount = Random.Range(0, expPrefab.Length);
            Vector2 vector2 = Random.insideUnitCircle * range;
            GameObject enemy = Instantiate(expPrefab[enemyCount], (Vector2)transform.position + vector2, Quaternion.identity);
            count++;
            if (count >= 10)
            {
                canSpawn = false;
            }
        }

    }

}
