using UnityEngine;
using TMPro;

public class MusicController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI textoBoton;

    [Header("Símbolos")]
    [SerializeField] private string simboloActivo = "♪";
    [SerializeField] private string simboloMute = "✕";

    private bool musicaActiva = true;

    private void Start()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        ActualizarBoton();
    }

    public void AlternarMusica()
    {
        if (audioSource == null) return;

        musicaActiva = !musicaActiva;

        if (musicaActiva)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }

        ActualizarBoton();
    }

    private void ActualizarBoton()
    {
        if (textoBoton != null)
        {
            textoBoton.text = musicaActiva ? simboloActivo : simboloMute;
        }
    }
}