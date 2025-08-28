using UnityEngine;

public class RandomExp : MonoBehaviour
{

    public GameObject[] expPrefab; // Gán Prefab EXP vào đây trong Inspector
    private float startDelay = 2f;
    private float spawnInterval = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnExp", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnExp()
    {
        int expCount = Random.Range(0, expPrefab.Length);
        Vector2 vector2 = Random.insideUnitCircle * 15f;
        Instantiate(expPrefab[expCount], (Vector2)transform.position + vector2, Quaternion.identity);
    }
}
