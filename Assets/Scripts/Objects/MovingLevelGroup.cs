using System.Collections;
using UnityEngine;
using static MovingLevel;

// Clase que representa un grupo de objetos del nivel móvil.
// Requiere asociarse al script general.
[RequireComponent(typeof(MovingLevel))]
public class MovingLevelGroup : MonoBehaviour
{
    public MovingLevel movingLevel; // Referencia al script general
    public float despawnDistance = 520; // Distancia de destrucción del objeto desde el origen del spawner.
    public float zDespawnLimit = -30; // Límite de destrucción del objeto en el eje z
    public float parallaxAmount = 1; // Intensidad de efecto "parallax" para el grupo

    public void Start()
    {
        registerPositionUpdates();
    }

    protected void registerPositionUpdates()
    {
        movingLevel.OnUpdatePositions += UpdatePositions;
    }

    /** Actualiza las posiciones de los objetos del grupo de acuerdo con el desplazamiento especificado.
     * A continuación se comprueba si el objeto sigue dentro de las coordenadas visibles del nivel.
     * Si está, no se hace nada. Si no está, se ejecuta OnOutOfBounds */
    protected virtual void UpdatePositions(Vector3 displacement)
    {
        foreach (Transform child in transform)
        {
            // Multiplica desplazamiento por factor parallax.
            child.position += displacement * parallaxAmount;
            //Debug.Log("Update" + displacement * parallaxAmount);

            // Comprobación de salida de zona visible
            if (!isPositionInsideBounds(child.position))
                OnOutOfBounds(child);
        }
    }

    /** Define el comportamiento a realizar cuando el objeto sale de la zona delimitada.
     * Por defecto se destruye, pero se puede modificar en las subclases que hereden. */
    protected virtual void OnOutOfBounds(Transform t)
    {
        Destroy(t.gameObject);
    }

    // Comprueba si la posición se encuentra dentro de los límites del nivel móvil.
    protected bool isPositionInsideBounds(Vector3 position)
    {
        return !(position.z < zDespawnLimit || (position.x - transform.position.x > despawnDistance) || (position.y - transform.position.y > despawnDistance));
    }
}
