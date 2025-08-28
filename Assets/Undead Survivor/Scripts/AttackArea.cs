using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;
    private bool hasAttacked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Attack");
            hasAttacked = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        // Debug.Log($"collider != null: {collider != null}");
        if (collider != null)
        {
            HealthTest health = collider.GetComponent<HealthTest>();
                // Debug.Log($"hasAttacked: {hasAttacked}");
            if(health != null)
            {
                if (hasAttacked)
                {
                    health.Damage(damage);
                    hasAttacked = false;
                }

            }
        }
    }
}
