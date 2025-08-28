using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI TextBox;

    public float playerHP = 100f;
    public TextMeshProUGUI playerHpText;
    public PlayerController playerController;
    private Animator anim;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;    

    public CodeHp codeHp;
    public float maxHealth = 100f;
    public float nowHealth;
    public bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdatePlayerHpText();
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
    }

    public void TakeDamage(float damage)
    {
        playerHP -= damage;
        nowHealth -= damage;
        codeHp.SetHealth(nowHealth, maxHealth);
        if (playerHP < 0)
        {
            playerHP = 0;
            Debug.Log("Player is dead!");
        }
        UpdatePlayerHpText();
    }

    private void UpdatePlayerHpText()
    {
        if (playerHpText != null)
        {
            playerHpText.text = "HP: " + playerHP.ToString("F0");
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


}
