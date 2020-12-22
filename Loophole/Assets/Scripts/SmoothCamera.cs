using UnityEngine;

public class SmoothCamera : MonoBehaviour {

    public Transform player; // Elemento a enfocar
    public Vector3 cameraDistance = Vector3.zero; // Posición de la cámara relativa al objeto que enfoca
    public float smoothingTime = 1f; // Tiempo de suavizado del movimiento (segundos)
    private Vector3 velocity = Vector3.zero; // Velocidad actual de la cámara

    void Update()
    {
        // Si se ha asignado un objeto que enfocar
        if (player)
        {
            // Interpola y suaviza el movimiento a la nueva posición
            transform.position = Vector3.SmoothDamp(transform.position, player.position + cameraDistance, ref velocity, smoothingTime);
        }
    }
}
