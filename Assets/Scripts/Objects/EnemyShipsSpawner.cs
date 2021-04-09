using UnityEngine;

public class EnemyShipsSpawner : MovingLevelGroup
{
    public GameObject enemySpaceship; // Objeto nave enemiga
    public GameObject playerSpaceship; // Objeto nave jugador
    public Vector3 spawnBoxSize; // Tamaño de la caja en la que se crean los objetos
    public float timeBetweenSpawns = 0.5f;// Tiempo entre spawns (nave enemiga)

    private float timeLeftToSpawn; // Tiempo restante para spawnear
    private Vector3 playerPosition; // Posición del jugador
    private GameObject instance; // Instancia nave enemiga
    private float timeLeftToRespawn = 0; // Tiempo restante para respawnear en misma posición

    new void Start()
    {
        registerPositionUpdates();
        playerPosition = playerSpaceship.transform.position; //Obtiene la posición inicial de jugador
    }

    void FixedUpdate()
    {
        //Controla el spawn de naves a través del tiempo
        if (timeLeftToSpawn <= 0)
        {
            SpawnObjects();
            timeLeftToSpawn = timeBetweenSpawns;
        }
        else
        {
            timeLeftToSpawn -= Time.deltaTime;
        }
    }

    // Crea objetos si todavía no se llegó al número límite
    private void SpawnObjects()
    {
        // Si el jugador no se mueve, spawneamos una nave en su misma posición (x e y) forzando así
        // su movimiento. Esperamos un tiempo entre el spawn de naves en la misma posición para evitar
        // que se alcacen entre ellas.
        if ((playerPosition.x - playerSpaceship.transform.position.x) < 5 && timeLeftToRespawn <= 0)
        {
            instance = Instantiate(enemySpaceship, new Vector3(playerPosition.x - 10, playerPosition.y, transform.position.z), Quaternion.identity);
            timeLeftToRespawn = 0.1f;
        }
        else
        {
            // Si el jugador se está moviendo, spawneamos naves en posiciones aleatorias
            timeLeftToRespawn -= Time.deltaTime;
            instance = Instantiate(enemySpaceship, transform.position + Utilities.RandomVector3(spawnBoxSize), Quaternion.identity);
        }

        // Obtiene la posición del jugador
        playerPosition = playerSpaceship.transform.position;

        // La coloca como hijo del objeto especificado
        instance.transform.SetParent(transform);

        // Fijamos la capa del objeto en como "enemies" para que se vea en el minimap
        instance.layer = 9;

    }

}
