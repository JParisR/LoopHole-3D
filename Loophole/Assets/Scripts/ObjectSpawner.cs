using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] asteroidTypes; // Array con tipos de objetos a crear
    public Vector3 spawnBoxSize; // Tamaño de la caja en la que se crean los objetos
    public Vector3 displacementSpeed; // Velocidad de los objetos respecto a la nave.
    public Vector3 maxRandomTranslationSpeed; // Velocidad máxima aleatoria al crear el objeto
    public Vector3 maxRandomRotationSpeed; // Rotación máxima aleatoria al crear el objeto
    public float despawnDistance; // Distancia de destrucción del objeto desde el origen del spawner.
    public int itemCount; // Límite de objetos simulados concurrentemente.

    private int spawnedObjects = 0; // Contador de objetos simulados

    void Update()
    {
        // No tengo claro si se debe llamar en Update o en FixedUpdate.
        // En FixedUpdate da "tirones" al no coincidir la frecuencia de gráficos con la de físicas.
        updatePositions();
    }

    void FixedUpdate()
    {
        if (spawnedObjects < itemCount)
            spawnObjects();
        //updatePositions();
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
        // Si el objeto se aleja más de despawnDistance desde el origen del spawn, lo destruye y decrementa el contador.
        if (t.position.magnitude - transform.position.magnitude > despawnDistance)
        {
            Destroy(t.gameObject);
            spawnedObjects--;
        }
    }

    // Crea objetos si todavía no se llegó al número límite
    private void spawnObjects()
    {
        // Para cada objeto en los tipos definidos
        foreach (GameObject o in asteroidTypes)
        {
            // Si todavía no se ha llegado al número máximo de objetos, crea uno.
            // De esta manera se van creando progresivamente uno por fotograma y no todos juntos.
            // Pendiente de retocar dependiendo de qué manera queremos que aparezcan los objetos.
            if (spawnedObjects < itemCount)
            {
                // Crea una instancia del objeto con posición aleatoria
                GameObject instance = Instantiate(o, transform.position + randomVector3(spawnBoxSize), randomAngle());

                // La coloca como hijo del spawner
                instance.transform.SetParent(transform);

                // Obtiene rigidbody para añadir una velocidad y rotación aleatorias
                Rigidbody rb = instance.GetComponent<Rigidbody>();
                rb.AddTorque(randomVector3(maxRandomRotationSpeed), ForceMode.VelocityChange);
                rb.AddForce(randomVector3(maxRandomTranslationSpeed), ForceMode.VelocityChange);

                // Aumenta contador de objetos simulados
                spawnedObjects++;
            }
        }
    }

    // Genera un Vector3 con valores aleatorios en el rango [-limit, limit]
    private Vector3 randomVector3(Vector3 limit)
    {
        return new Vector3(
                            Random.Range(-limit.x, limit.x),
                            Random.Range(-limit.y, limit.y),
                            Random.Range(-limit.z, limit.z)
                        );
    }

    // Genera un Quaternion con ángulos aleatorios
    private Quaternion randomAngle()
    {
        return Quaternion.Euler(
                            Random.Range(0, 360),
                            Random.Range(0, 360),
                            Random.Range(0, 360)
                        );
    }
}
