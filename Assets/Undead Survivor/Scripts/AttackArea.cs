using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;
    public bool hasAttacked = false;
    public bool hasDamaged = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !hasAttacked)
        {
            Debug.Log("Attack");
            hasAttacked = true;
            Debug.Log($"hasAttacked: {hasAttacked}");
        }
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider != null)
        {
            if(hasAttacked && !hasDamaged && collider.CompareTag("Monster"))
            {
                Debug.Log("AttackArea hit the enemy!");
                hasDamaged = true;
            }

        }
    }
}
