using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHP = 100f;
    public TextMeshProUGUI playerHpText;
    public PlayerController playerController;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdatePlayerHpText();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"playerController == null: {playerController == null}");
        if (playerController == null) return;
        if (playerController.isMoving)
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
        if (collision.CompareTag("Box"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Box Collected");
        }
        else if (collision.CompareTag("Exp1"))
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
}
