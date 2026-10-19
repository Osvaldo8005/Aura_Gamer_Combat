using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private int valor = 1;
    [SerializeField] private float velocidadRotacion = 100f;
    [SerializeField] private AudioClip sonidoRecoger;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Rotate(0f, velocidadRotacion * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moneda recolectada. Valor: " + valor);

            if (sonidoRecoger != null)
            {
                AudioSource.PlayClipAtPoint(sonidoRecoger, transform.position);
            }

            if (gameManager != null)
            {
                gameManager.SumarMonedas(valor);
            }

            Destroy(gameObject);
        }
    }
}