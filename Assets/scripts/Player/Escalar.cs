using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LadderClimbing : MonoBehaviour
{
    public float climbSpeed = 5f; // Velocidad al escalar
    private bool isClimbing = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Escaleras"))
        {
            isClimbing = true;
            rb.gravityScale = 0; // Desactiva la gravedad al escalar
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Escaleras"))
        {
            isClimbing = false;
            rb.gravityScale = 1; // Restaura la gravedad
        }
    }

    void Update()
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
        }
    }
}
