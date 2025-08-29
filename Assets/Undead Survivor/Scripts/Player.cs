using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI TextBox;

    public float playerHP = 100f;
    public PlayerController playerController;
    private Animator anim;
    public Rigidbody2D rb;
    public Button btnSkill1;
    public Button btnSkill2;
    public Button btnSkill3;

    public float moveSpeed = 5f;   
    public float maxSpeed = 10f;

    public CodeHp codeHp;
    public float maxHealth = 100f;
    public float nowHealth;
    public GameObject skillObj;
    public bool isMoving = false;
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

    }

    public void TakeDamage(float damage)
    {
        playerHP -= damage;
        nowHealth -= damage;
        codeHp.SetHealth(nowHealth, maxHealth);
        if (playerHP < 0)
        {
            playerHP = 0;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Exp1"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Player hit by Enemy1");
        }
        else if (collision.CompareTag("Exp2"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Player hit by Enemy2");
        }
        else if (collision.CompareTag("Exp3"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Player hit by Enemy3");
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
        else
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
