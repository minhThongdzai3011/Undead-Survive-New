using UnityEngine;

public class HealthTest : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int MAX_HEALTH = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        Debug.Log($"amount: {amount}");
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Damage amount cannot be negative");
        }
        this.health -= amount;

        if (this.health <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Heal amount cannot be negative");
        }

        bool wouldBeOverMaxHealth = this.health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("Entity is dead!");
        Destroy(this.gameObject);
    }
}
