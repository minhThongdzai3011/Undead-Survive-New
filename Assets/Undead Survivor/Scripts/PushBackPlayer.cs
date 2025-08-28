using UnityEngine;
using System.Collections;

public class KnockbackController : MonoBehaviour
{


    void Start()
    {
       
    }
    private bool isPushed = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPushed)
        {
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            float pushDistance = 1.5f;
            float pushDuration = 0.2f;

            StartCoroutine(PushBack(pushDirection, pushDistance, pushDuration));
        }
    }

    IEnumerator PushBack(Vector2 direction, float distance, float duration)
    {
        isPushed = true;

        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (Vector3)(direction * distance);

        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isPushed = false;
    }

}