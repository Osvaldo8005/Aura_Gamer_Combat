using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}