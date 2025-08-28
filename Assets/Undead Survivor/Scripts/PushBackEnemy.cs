using UnityEngine;

public class PushBackEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
        float pushDistance = 2f;
        transform.position += (Vector3)(pushDirection * pushDistance);
    }

}
