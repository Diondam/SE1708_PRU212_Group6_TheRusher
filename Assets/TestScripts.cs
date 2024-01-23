using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the sprite movement
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    void Update()
    {
        // Change color randomly
        if (Random.value < 0.01f) // 1% chance per frame
        {
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }

        // Move forward and backward
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // Get input from 'A' and 'D' keys
        transform.position += new Vector3(move, 0, 0); // Update position
    }
}