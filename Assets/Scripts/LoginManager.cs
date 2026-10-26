using UnityEngine;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TMP_InputField inputUsuario;
    [SerializeField] private TextMeshProUGUI textoDios; // Referencia al texto que dice DIOS
    [SerializeField] private GameObject menuInicio;

    private GameManager gameManager;
    private PlayerController playerController;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerController = FindFirstObjectByType<PlayerController>();

        // Bloquea el movimiento hasta iniciar sesion
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (PlayerPrefs.HasKey("UsuarioActual"))
        {
            string usuarioGuardado = PlayerPrefs.GetString("UsuarioActual");
            if (inputUsuario != null)
            {
                inputUsuario.text = usuarioGuardado;
            }

            // Si ya hay un usuario guardado, lo mostramos en el texto
            if (textoDios != null)
            {
                textoDios.text = usuarioGuardado;
            }
        }
    }

    public void IniciarSesion()
    {
        if (inputUsuario == null) return;

        string nombre = inputUsuario.text.Trim();

        // Si el nombre esta vacio, no permite iniciar
        if (string.IsNullOrEmpty(nombre))
        {
            Debug.LogWarning("El nombre de usuario esta vacio.");
            return;
        }

        // Guarda el nombre en memoria
        PlayerPrefs.SetString("UsuarioActual", nombre);
        PlayerPrefs.Save();

        // Muestra el nombre en el texto de DIOS
        if (textoDios != null)
        {
            textoDios.text = nombre;
        }

        // Obliga al GameManager a leer el nuevo puntaje
        if (gameManager != null)
        {
            gameManager.CargarProgreso();
        }

        // Oculta el menu y habilita el juego
        if (menuInicio != null)
        {
            menuInicio.SetActive(false);
        }

        if (playerController != null)
        {
            playerController.enabled = true;
        }

        Debug.Log("Sesion iniciada como: " + nombre);
    }
}
