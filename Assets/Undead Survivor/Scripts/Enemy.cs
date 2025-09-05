using System.Collections;
using TMPro;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int enemyID;
    private EnemyData enemyData;
    private GameObject player;
    private Player playerScript;
    public AttackArea attackArea;
    public Rigidbody2D rb;
    private bool damagedSkill1 = true;
    public int killCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
        }
        EnemyData _enemy = Resources.Load<EnemyData>($"Enemy{enemyID}");
        Debug.Log($"name: {name} ==> {_enemy.hp}");
        enemyData = new EnemyData(_enemy.hp, _enemy.damageToPlayer, _enemy.moveSpeed);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyData.hp <= 0f)
        {
            Debug.Log("Enemy is dead!");
            playerScript.countEnemy++;
            Debug.Log($"playerScript.countEnemy: {playerScript.countEnemy}");
            Destroy(gameObject);
        }   
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
            //Debug.Log("Enemy hit the player!");
            if (playerScript != null)
            {
                playerScript.TakeDamage(enemyData.damageToPlayer);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision != null) Debug.Log("Enemy collided with: " + collision.collider.name);
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");
            if (playerScript != null)
            {
                StartCoroutine(WaitOneSecond());
                playerScript.TakeDamage(enemyData.damageToPlayer);

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Amount") && attackArea.hasDamaged == true)
        {
            attackArea.hasDamaged = false;
            attackArea.hasAttacked = false;
            enemyData.hp -= playerScript.damage;
            Debug.Log($"Enemy took damage, remaining HP: {enemyData.hp} , {gameObject.name}");
        }
        if (collision.CompareTag("Skill1") && damagedSkill1)
        {
            damagedSkill1 = false;
            StartCoroutine(WaitOneSecondSkill1());
            Debug.Log($"Enemy HP: {enemyData.hp}");
        }
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("One second has passed.");
        rb.linearVelocity = Vector2.zero;

    }
    IEnumerator WaitOneSecondSkill1()
    {
        yield return new WaitForSeconds(1f);
        enemyData.hp -= 10;
        Debug.Log($"Enemy took damage, remaining HP: {enemyData.hp} , {gameObject.name}");
        damagedSkill1 = true;
    }
}
