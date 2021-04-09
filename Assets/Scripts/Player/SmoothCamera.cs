using UnityEngine;

public class SmoothCamera : MonoBehaviour {

    public Transform player; // Elemento a enfocar
    public Vector3 cameraDistance = Vector3.zero; // Posición de la cámara relativa al objeto que enfoca
    public float smoothingTime = 1f; // Tiempo de suavizado del movimiento (segundos)
    public float movementFactor = 1f; // Cantidad de movimiento desde el centro (efecto "parallax")
    private Vector3 velocity = Vector3.zero; // Velocidad actual de la cámara

    void Update()
    {
        // Si se ha asignado un objeto que enfocar
        if (player)
        {
            // Interpola y suaviza el movimiento a la nueva posición
            transform.position = Vector3.SmoothDamp(transform.position, (player.position) * movementFactor + cameraDistance, ref velocity, smoothingTime);
        }
    }
}
