using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables en inspector
    public float speed = 5f;
    public float jumpForce = 3f;
    public float ceilDistance = 1f;

    public Animator cAnimator;
    public Rigidbody2D cRigidbody; // rigidbody
    public SpriteRenderer cRenderer;
    public CapsuleCollider2D cCollider;

    // Variable no inspector
    private Vector2 move;
    private bool grounded;
    private bool crouched;

    private bool jumpKey;
    private bool crouchKey;

    // Variables para doble salto
    private bool canDoubleJump = false; // Si puede hacer doble salto
    private bool hasCollectedGem = false; // Si ha recogido la gema

    // Start is called before the first frame update
    void Start()
    {
        cCollider = GetComponent<CapsuleCollider2D>();
        cRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        jumpKey = Input.GetKeyDown(KeyCode.W);
        crouchKey = Input.GetKey(KeyCode.S);

        // Estoy saltando
        if (jumpKey && (grounded || (hasCollectedGem && canDoubleJump)))
        {
            cRigidbody.velocity = new Vector2(cRigidbody.velocity.x, jumpForce); // Vector2.up == new Vector2(0,1)

            PlayerAudioController hAudio = gameObject.GetComponent<PlayerAudioController>();
            hAudio.Jump();

            cAnimator.SetBool("Jump", true);

            if (!grounded && hasCollectedGem && canDoubleJump)
            {
                canDoubleJump = false; // Consumir el doble salto
                hasCollectedGem = false ;
            }
        }

        cAnimator.SetFloat("Speed", Mathf.Abs(cRigidbody.velocity.x));

        PlayerOrientation();
    }

    void FixedUpdate()
    {
        PlayerGrounded();
        PlayerCrouched();

        // Accedo al componente rigidbody 2d
        cRigidbody.velocity = new Vector2(move.x * speed, cRigidbody.velocity.y);
    }

    void PlayerOrientation()
    {
        // Accedo al componente Sprite Renderer
        if (move.x < 0)
            cRenderer.flipX = true;
        else if (move.x > 0)
            cRenderer.flipX = false;
    }

    // Ground detection
    void PlayerGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.05f, LayerMask.GetMask("Environment"));

        if (hit && !grounded) // Check if we have a hit, if not, hit is null and will not enter
        {
            grounded = true;
            cAnimator.SetBool("Jump", false);
            canDoubleJump = true; // Reinicia el doble salto al tocar el suelo
        }
        else if (!hit)
        {
            grounded = false;
        }
    }

    // Ceiling and crouch detection
    void PlayerCrouched()
    {
        bool hit = Physics2D.Raycast(transform.position + Vector3.up * 0.1f, Vector2.up, ceilDistance, LayerMask.GetMask("Environment"));
        bool isCrouched = hit || crouchKey;

        if (isCrouched)
        {
            cCollider.size = new Vector2(cCollider.size.x, 0.17f);
            cCollider.offset = new Vector2(0, 0.09f);
            crouched = true;
        }
        else
        {
            cCollider.size = new Vector2(cCollider.size.x, 0.26f);
            cCollider.offset = new Vector2(0, 0.13f);
            crouched = false;
        }

        cAnimator.SetBool("Crouch", isCrouched);
    }

    // Detectar si recoge la gema
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            hasCollectedGem = true; // Habilitar el doble salto
            Destroy(collision.gameObject); // Eliminar la gema del juego
        }

    }
   
}