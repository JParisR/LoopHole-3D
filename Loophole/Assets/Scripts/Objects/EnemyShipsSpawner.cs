using UnityEngine;

public class EnemyShipsSpawner : MonoBehaviour
{
    public GameObject[] asteroidTypes; // Array con tipos de objetos a crear
    public Vector3 spawnBoxSize; // Tamaño de la caja en la que se crean los objetos
    public Vector3 maxRandomTranslationSpeed; // Velocidad máxima aleatoria al crear el objeto
    public Vector3 maxRandomRotationSpeed; // Rotación máxima aleatoria al crear el objeto
    public int itemCount = 5; // Límite de objetos simulados concurrentemente.
    public MovingLevel movingLevelScript;
    public Transform spawnedObjectsParent;
    public float timeWait = 1;
    private float timeBetwenShoots;
    public GameObject explosionEfects;

    private int spawnedObjects = 0; // Contador de objetos simulados

    private void Start()
    {
        movingLevelScript.OnDespawn += DecreaseSpawnCounter;
    }

    void FixedUpdate()
    {
        if (timeBetwenShoots <= 0)
        {
            SpawnObjects();
            timeBetwenShoots = timeWait;
            itemCount++;
        }
        else
        {
            timeBetwenShoots -= Time.deltaTime;
        }
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

                // Crea una instancia del objeto con posición aleatoria
                GameObject instance = Instantiate(o, transform.position + Utilities.RandomVector3(spawnBoxSize), Quaternion.identity);

                // La coloca como hijo del objeto especificado
                instance.transform.SetParent(spawnedObjectsParent);

                // Obtiene rigidbody para añadir una velocidad y rotación aleatorias
                Rigidbody rb = instance.GetComponent<Rigidbody>();

                // Aumenta contador de objetos simulados
                spawnedObjects++;

        }
    }

    private void DecreaseSpawnCounter()
    {
        spawnedObjects--;
    }


}