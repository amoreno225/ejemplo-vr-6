using UnityEngine;
using UnityEngine.UI;

public class HingeAngleDisplay : MonoBehaviour
{
    [Header("Componentes")]
    public HingeJoint hinge;                     // Hinge Joint que quieres medir
    public UnityEngine.UI.Text angleText;        // Texto en el Canvas
    public GameObject piezaAEliminar;
    public GameObject piezaAEliminar2; // Objeto que se desactivará
    public AudioSource sonido;                   // Fuente de audio que reproducirá el sonido
    public GameObject piezaActivar;              // Objeto que se activará
    public Transform nuevaPosicion;              // Punto de destino para la pieza que se activará

    [Header("Configuración")]
    public float anguloObjetivo = 45f;           // Ángulo que debe alcanzar
    public bool mostrarEnGrados = true;
    private bool sonidoReproducido = false;      // Para que solo suene una vez
    private bool yaActivado = false;             // Evita reactivar varias veces



    private void Update()
    {
        if (hinge == null || angleText == null) return;

        // Obtener el ángulo actual del Hinge Joint
        float anguloActual = hinge.angle;
        float angulonuevo = hinge.angle / 15;
        float valorabs = Mathf.Abs(anguloActual)/15;
        // Mostrar en el texto
        angleText.text = "Torque: " + valorabs.ToString("F1");

        // Si el ángulo supera o iguala el objetivo
        if (!yaActivado && Mathf.Abs(anguloActual) >= Mathf.Abs(anguloObjetivo))
        {
            yaActivado = true; // Evitar repetir la acción

            // Desactivar pieza
            if (piezaAEliminar != null && piezaAEliminar.activeSelf)
            {
                piezaAEliminar.SetActive(false);
                piezaAEliminar.SetActive(false);

            }

            // 🔁 Mover la pieza que se activará antes de encenderla
            if (piezaActivar != null && nuevaPosicion != null)
            {
                piezaActivar.transform.position = nuevaPosicion.position;
                piezaActivar.transform.rotation = nuevaPosicion.rotation;
            }

            // Activar pieza
            if (piezaActivar != null)
            {
                piezaActivar.SetActive(true);

            }

            // Actualizar texto
            angleText.text += "\nObjetivo alcanzado!";

            // 🔊 Reproducir el sonido una sola vez
            if (!sonidoReproducido && sonido != null)
            {
                sonido.Play();
                sonidoReproducido = true;
            }
        }
    }
}
