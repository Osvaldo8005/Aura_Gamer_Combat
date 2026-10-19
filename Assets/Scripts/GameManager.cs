using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TextMeshProUGUI textoMonedas;

    [Header("Sonidos")]
    [SerializeField] private AudioClip sonidoPremio;

    private int monedasActuales = 0;
    private int siguientePremio = 50;

    private void Start()
    {
        // Carga directo de la memoria al iniciar el juego
        CargarProgreso();
    }

    public void CargarProgreso()
    {
        string usuario = PlayerPrefs.GetString("UsuarioActual", "");
        
        if (!string.IsNullOrEmpty(usuario))
        {
            monedasActuales = PlayerPrefs.GetInt("Poder_" + usuario, 0);
        }
        else
        {
            monedasActuales = 0;
        }

        ActualizarTexto();
        siguientePremio = ((monedasActuales / 50) + 1) * 50;
    }

    public void SumarMonedas(int cantidad)
    {
        monedasActuales += cantidad;
        ActualizarTexto();

        if (monedasActuales >= siguientePremio)
        {
            ReproducirPremio();
            siguientePremio += 50;
        }

        // Guarda directo en memoria
        string usuario = PlayerPrefs.GetString("UsuarioActual", "");
        if (!string.IsNullOrEmpty(usuario))
        {
            PlayerPrefs.SetInt("Poder_" + usuario, monedasActuales);
            PlayerPrefs.Save();
        }
    }

    private void ActualizarTexto()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "PODER: " + monedasActuales;
        }
    }

    private void ReproducirPremio()
    {
        if (sonidoPremio != null)
        {
            AudioSource.PlayClipAtPoint(sonidoPremio, Camera.main.transform.position);
        }
    }
}