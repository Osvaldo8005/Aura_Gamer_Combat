using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 8f;
    [SerializeField] private float tiempoDeVida = 2f;

    [Header("Crecimiento")]
    [SerializeField] private float escalaInicial = 0.5f;
    [SerializeField] private float escalaMaxima = 2f;
    [SerializeField] private float velocidadCrecimiento = 1.5f;

    [Header("Explosión")]
    [SerializeField] private float escalaExplosion = 4f;
    [SerializeField] private float duracionExplosion = 0.3f;
    [SerializeField] private AudioClip sonidoExplosion;

    private Vector2 direccion;
    private float tiempoVivido = 0f;
    private bool explotando = false;
    private float tiempoExplosion = 0f;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    public void Configurar(Vector2 nuevaDireccion, float nuevaVelocidad)
    {
        direccion = nuevaDireccion.normalized;
        velocidad = nuevaVelocidad;
        transform.localScale = Vector3.one * escalaInicial;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!explotando)
        {
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);

            float escalaActual = Mathf.Lerp(escalaInicial, escalaMaxima, tiempoVivido / tiempoDeVida);
            transform.localScale = Vector3.one * escalaActual;

            tiempoVivido += Time.deltaTime;
            if (tiempoVivido >= tiempoDeVida)
            {
                Explotar();
            }
        }
        else
        {
            tiempoExplosion += Time.deltaTime;
            float progreso = tiempoExplosion / duracionExplosion;
            transform.localScale = Vector3.one * Mathf.Lerp(escalaMaxima, escalaExplosion, progreso);

            // Desvanecer el sprite
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = Mathf.Lerp(1f, 0f, progreso);
                spriteRenderer.color = color;
            }

            if (tiempoExplosion >= duracionExplosion)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!explotando && !other.CompareTag("Player"))
        {
            Explotar();
        }
    }

    private void Explotar()
    {
        if (explotando) return;
        explotando = true;
        tiempoExplosion = 0f;
        Debug.Log("¡Proyectil explotó!");

        if (audioSource != null && sonidoExplosion != null)
        {
            audioSource.PlayOneShot(sonidoExplosion);
        }
    }
}