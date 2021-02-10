using UnityEngine;

public class MovingLevel : MonoBehaviour
{
    public Vector3 displacementSpeed; // Velocidad de los objetos respecto a la nave.

    // Función para comprobar si el objeto está dentro de los límites del nivel móvil.
    public delegate bool MovingLevelBoundsCheck(Vector3 position);

    // Función y evento para actualizar las posiciones de todos los objetos del nivel móvil.
    public delegate void UpdatePositions(Vector3 displacement/*, MovingLevelBoundsCheck boundCheck*/);
    public event UpdatePositions OnUpdatePositions;

    void Update()
    {
        // Actualiza posiciones de todos los grupos de objetos en cada fotograma.
        OnUpdatePositions?.Invoke(Time.deltaTime * displacementSpeed);
    }

    // Método para variar la velocidad de desplazamiento.
    // Por ejemplo, para permitir a la nave ir más rápido temporalmente.
    public void setSpeed(Vector3 speed)
    {
        displacementSpeed = speed;
    }
}
