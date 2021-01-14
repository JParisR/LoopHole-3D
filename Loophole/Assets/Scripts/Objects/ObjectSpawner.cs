using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] asteroidTypes; // Array con tipos de objetos a crear
    public Vector3 spawnBoxSize; // Tamaño de la caja en la que se crean los objetos
    public Vector3 maxRandomTranslationSpeed; // Velocidad máxima aleatoria al crear el objeto
    public Vector3 maxRandomRotationSpeed; // Rotación máxima aleatoria al crear el objeto
    public int itemCount; // Límite de objetos simulados concurrentemente.
    public bool enemyObjects;

    public MovingLevel movingLevelScript;
    public Transform spawnedObjectsParent;

    private int spawnedObjects = 0; // Contador de objetos simulados

    private void Start()
    {
        movingLevelScript.OnDespawn += DecreaseSpawnCounter;
    }

    void FixedUpdate()
    {
        if (spawnedObjects < itemCount)
            SpawnObjects();
    }

    // Crea objetos si todavía no se llegó al número límite
    private void SpawnObjects()
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
                GameObject instance = Instantiate(o, transform.position + Utilities.RandomVector3(spawnBoxSize), Utilities.RandomAngle());

                // La coloca como hijo del objeto especificado
                instance.transform.SetParent(spawnedObjectsParent);

                // 
                if(enemyObjects == true)
                {
                    instance.layer = 9;
                    foreach (Transform trans in instance.GetComponentsInChildren<Transform>(true))
                    {
                        trans.gameObject.layer = 9;
                    }
                }

                // Obtiene rigidbody para añadir una velocidad y rotación aleatorias
                Rigidbody rb = instance.GetComponent<Rigidbody>();
                rb.AddTorque(Utilities.RandomVector3(maxRandomRotationSpeed), ForceMode.VelocityChange);
                rb.AddForce(Utilities.RandomVector3(maxRandomTranslationSpeed), ForceMode.VelocityChange);

                // Aumenta contador de objetos simulados
                spawnedObjects++;
            }
        }
    }

    private void DecreaseSpawnCounter()
    {
        spawnedObjects--;
    }
}
