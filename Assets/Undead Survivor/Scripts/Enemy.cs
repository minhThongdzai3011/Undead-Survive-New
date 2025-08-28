using UnityEngine;


public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    private GameObject player;
    private Player playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * enemyData.moveSpeed * Time.fixedDeltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null) Debug.Log("Enemy collided with: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");
            if (playerScript != null)
            {
                playerScript.TakeDamage(enemyData.damageToPlayer);
                Destroy(gameObject);
            }
        }
    }
}
