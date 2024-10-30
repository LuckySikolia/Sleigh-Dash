using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public Rigidbody rb;

    // Variables to track vertical movement
    private bool moveUp = false;
    private bool moveDown = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("PlayerController started.");
    }

    // Method to move the player up
    public void MoveUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, speed, rb.velocity.z);
        Debug.Log("Moving Up");
    }

    // Method to move the player down
    public void MoveDown()
    {
        rb.velocity = new Vector3(rb.velocity.x, -speed, rb.velocity.z);
        Debug.Log("Moving Down");
    }

    // Method to stop the player
    public void StopMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Debug.Log("Stopped Moving");
    }

    // Methods for button interactions
    public void PointerDownUp() // Called when the button is pressed down
    {
        moveUp = true;
        Debug.Log("Pointer Down - Moving Up");
    }

    public void PointerUpUp() // Called when the button is released
    {
        moveUp = false;
        Debug.Log("Pointer Up - Stopped Moving Up");
    }

    public void PointerDownDown() // Called when the button is pressed down
    {
        moveDown = true;
        Debug.Log("Pointer Down - Moving Down");
    }

    public void PointerUpDown() // Called when the button is released
    {
        moveDown = false;
        Debug.Log("Pointer Up - Stopped Moving Down");
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //float verticalMove = 0;
        float verticalMove = speed;

        if (moveUp)
        {
            verticalMove = speed; // Move up
            Debug.Log("Moving Up");
        }
        else if (moveDown)
        {
            verticalMove = -speed; // Move down
            Debug.Log("Moving Down");
        }
        else
        {
            verticalMove = 0;
            Debug.Log("Stopped Moving");
        }

        // Apply movement
        rb.velocity = new Vector3(rb.velocity.x, verticalMove, rb.velocity.z); // Maintain current x and z velocity
        Debug.Log($"Current Velocity: {rb.velocity}");
    }
}
