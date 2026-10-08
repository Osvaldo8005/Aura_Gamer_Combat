using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Objetivo")]
    [SerializeField] private Transform objetivo;

    [Header("Suavidad")]
    [SerializeField] private float suavidad = 5f;

    [Header("Offset")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 1f, -10f);

    [Header("Limites (opcional)")]
    [SerializeField] private bool usarLimites = false;
    [SerializeField] private float limiteIzquierdo = -20f;
    [SerializeField] private float limiteDerecho = 20f;

    private void LateUpdate()
    {
        if (objetivo == null) return;

        Vector3 posicionDeseada = objetivo.position + offset;

        if (usarLimites)
        {
            posicionDeseada.x = Mathf.Clamp(posicionDeseada.x, limiteIzquierdo, limiteDerecho);
        }

        Vector3 posicionSuavizada = Vector3.Lerp(
            transform.position,
            posicionDeseada,
            suavidad * Time.deltaTime
        );

        transform.position = new Vector3(
            posicionSuavizada.x,
            posicionSuavizada.y,
            offset.z
        );
    }
}