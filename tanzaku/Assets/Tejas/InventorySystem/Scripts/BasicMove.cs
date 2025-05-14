using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement

    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.A)) // Move left
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.D)) // Move right
        {
            move = 1f;
        }

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y); // Apply horizontal movement
    }
}