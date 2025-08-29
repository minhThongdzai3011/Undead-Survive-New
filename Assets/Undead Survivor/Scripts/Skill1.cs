using UnityEngine;
using System.Collections;

public class Skill1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EnemyData enemyData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monter"))
        {
            enemyData.hp -= 10;
            Debug.Log($"Enemy took damage, remaining HP: {enemyData.hp}");
            StartCoroutine(WaitOneSecond());
        }
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        enemyData.hp -= 10;
        Debug.Log($"Enemy took damage, remaining HP: {enemyData.hp}");
    }
}
