using UnityEngine;

public class MovingLevel : MonoBehaviour
{
    public Vector3 displacementSpeed; // Velocidad de los objetos respecto a la nave.
    public float despawnDistance; // Distancia de destrucción del objeto desde el origen del spawner.
    public float zDespawnLimit; // Límite de destrucción del objeto en el eje z.

    // Evento para destrucción de objeto por distancia
    public delegate void Despawn();
    public event Despawn OnDespawn;

    void Update()
    {
        updatePositions();
    }

    // Método para variar la velocidad de desplazamiento.
    // Por ejemplo, para permitir a la nave ir más rápido temporalmente.
    public void setSpeed(Vector3 speed)
    {
        displacementSpeed = speed;
    }

    private void updatePositions()
    {
        foreach (Transform child in transform)
        {
            child.localPosition += Time.deltaTime * displacementSpeed;
            destroyIfDistant(child);
        }
    }

    // Destruye el objeto si se aleja más de la distancia límite.
    private void destroyIfDistant(Transform t)
    {
        // Si el objeto se aleja más de despawnDistance desde el origen del spawn, lo destruye.
        if (t.position.z < zDespawnLimit || (t.position.x - transform.position.x > despawnDistance) || (t.position.y - transform.position.y > despawnDistance))
        {
            Destroy(t.gameObject);
            OnDespawn?.Invoke();
        }
    }
}
