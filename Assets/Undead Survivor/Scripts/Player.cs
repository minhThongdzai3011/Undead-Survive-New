using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI TextBox;

    public float playerHP = 100f;
    public PlayerController playerController;
    public Text levelText;
    public TextMeshProUGUI playerHealthText;
    private Animator anim;
    public Rigidbody2D rb;
    public Button btnSkill1;
    public Button btnSkill2;
    public Button btnSkill3;
    public GameObject lose;
    public int levelPlayer = 0;
    public int expLevel = 100;
    public int expNow = 0;
    public float moveSpeed = 5f;   
    public float maxSpeed = 10f;
    public int damage = 20;
    public CodeHp codeHp;
    public float maxHealth = 100f;
    public float nowHealth;
    public GameObject skillObj;
    public bool isMoving = false;
    public bool isLose = false;
    public int countCoin = 0;
    public int countEnemy = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        nowHealth = maxHealth;
        codeHp.SetHealth(nowHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            isMoving = true;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (playerController == null) return;
        if (isMoving)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }



        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Skill 1 activated");
            BtnSkill1();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Skill 2 activated");
            BtnSkill2();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Skill 3 activated");
            BtnSkill3();
        }

        if (expNow >= expLevel)
        {
            levelPlayer++;
            expNow -= expLevel;
            expLevel += 50;
            maxHealth += 10f;
            nowHealth = maxHealth;
            codeHp.SetHealth(nowHealth, maxHealth);
            playerHP = maxHealth;
            damage += 1;
        }
        levelText.text = "Level: " + levelPlayer.ToString();
        playerHealthText.text = playerHP.ToString();
    }

    public void TakeDamage(float damage)
    {
        playerHP -= damage;
        nowHealth -= damage;
        codeHp.SetHealth(nowHealth, maxHealth);
        if (playerHP <= 0)
        {
            playerHP = 0;
            playerHealthText.text = playerHP.ToString();
            Destroy(gameObject);
            lose.gameObject.SetActive(true);
            isLose = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Exp1"))
        {
            Destroy(collision.gameObject);
            expNow += 10;
            Debug.Log("Player hit by Enemy1");
        }
        else if (collision.CompareTag("Exp2"))
        {
            Destroy(collision.gameObject);
            expNow += 20;
            Debug.Log("Player hit by Enemy2");
        }
        else if (collision.CompareTag("Exp3"))
        {
            Destroy(collision.gameObject);
            expNow += 30;
            Debug.Log("Player hit by Enemy3");
        }
        else if (collision.CompareTag("Coin"))
        {
            countCoin+=1;
            Destroy(collision.gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log("Player is near the box. Press M to open.");
            TextBox.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.M))
            {
                TextBox.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            TextBox.gameObject.SetActive(false);
        }
    }
    public void BtnSkill1()
    {
        skillObj.SetActive(true);
        StartCoroutine(WaitFiveSecondSkill1());

    }

    public void BtnSkill2()
    {
        moveSpeed = maxSpeed;
        StartCoroutine(WaitThreeSecondSkill2());
    }

    public void BtnSkill3()
    {
        nowHealth += 20f;
        if (nowHealth > maxHealth)
        {
            nowHealth = maxHealth;
        }
        codeHp.SetHealth(nowHealth, maxHealth);
        btnSkill3.gameObject.SetActive(false);
        StartCoroutine(WaitTwentySecond());
    }

    IEnumerator WaitFiveSecondSkill1()
    {
        btnSkill1.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f); 
        btnSkill1.gameObject.SetActive(true);
        skillObj.SetActive(false);
    }

    IEnumerator WaitThreeSecondSkill2()
    {
        btnSkill2.gameObject.SetActive(false);
        moveSpeed = maxSpeed;
        yield return new WaitForSeconds(3f); 
        moveSpeed = 5f;
        btnSkill2.gameObject.SetActive(true);
    }

    IEnumerator WaitTwentySecond()
    {
        yield return new WaitForSeconds(20f);
        btnSkill3.gameObject.SetActive(true);
    }
}
