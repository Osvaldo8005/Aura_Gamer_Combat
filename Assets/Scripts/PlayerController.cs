using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Disparo")]
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float velocidadProyectil = 8f;
    [SerializeField] private float cooldownDisparo = 0.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalInput;
    private bool isGrounded;
    private bool facingRight = true;
    private float tiempoUltimoDisparo = 0f;

    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ReadInput();
        CheckGrounded();
        HandleJump();
        HandleShoot();
        UpdateAnimations();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private void ReadInput()
    {
        horizontalInput = 0f;

        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            horizontalInput = -1f;
        else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            horizontalInput = 1f;
    }

    private void HandleJump()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void HandleShoot()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        // Ctrl + F para disparar
        bool ctrlPresionado = keyboard.leftCtrlKey.isPressed || keyboard.rightCtrlKey.isPressed;
        bool fPresionada = keyboard.fKey.wasPressedThisFrame;

        if (ctrlPresionado && fPresionada && Time.time >= tiempoUltimoDisparo + cooldownDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    private void Disparar()
    {
        if (proyectilPrefab == null)
        {
            Debug.LogWarning("No hay Prefab de proyectil asignado.");
            return;
        }

        // Determinar posición de origen
        Vector2 origen = puntoDisparo != null
            ? (Vector2)puntoDisparo.position
            : (Vector2)transform.position;

        // Determinar dirección
        Vector2 direccion = facingRight ? Vector2.right : Vector2.left;

        // Crear el proyectil
        GameObject nuevoProyectil = Instantiate(proyectilPrefab, origen, Quaternion.identity);

        // Configurar el proyectil
        Projectile script = nuevoProyectil.GetComponent<Projectile>();
        if (script != null)
        {
            script.Configurar(direccion, velocidadProyectil);
        }

        Debug.Log("¡Proyectil disparado hacia " + (facingRight ? "derecha" : "izquierda") + "!");
    }

    private void CheckGrounded()
    {
        if (groundCheck == null)
        {
            isGrounded = false;
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void UpdateAnimations()
    {
        animator.SetFloat(SpeedHash, Mathf.Abs(horizontalInput));
        animator.SetBool(IsGroundedHash, isGrounded);
    }

    private void FlipSprite()
    {
        if (horizontalInput > 0f && !facingRight)
            Flip();
        else if (horizontalInput < 0f && facingRight)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}