using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    public float speed;
    public bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputHorizontal, inputVertical, 0f);
        transform.position += movement * speed * Time.deltaTime;

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
    }


}
