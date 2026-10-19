using UnityEngine;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TMP_InputField inputUsuario;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        if (PlayerPrefs.HasKey("UsuarioActual"))
        {
            inputUsuario.text = PlayerPrefs.GetString("UsuarioActual");
        }
    }

    public void IniciarSesion()
    {
        if (inputUsuario == null) return;

        string nombre = inputUsuario.text.Trim();
        if (string.IsNullOrEmpty(nombre))
        {
            Debug.LogWarning("El nombre de usuario esta vacio.");
            return;
        }

        // Guarda el nombre en memoria
        PlayerPrefs.SetString("UsuarioActual", nombre);
        PlayerPrefs.Save();

        // Obliga al GameManager a leer el nuevo puntaje
        if (gameManager != null)
        {
            gameManager.CargarProgreso();
        }

        Debug.Log("Sesion iniciada como: " + nombre);
    }
}