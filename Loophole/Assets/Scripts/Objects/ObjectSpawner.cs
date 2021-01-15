using System.Collections;
using UnityEngine;

public class ObjectSpawner : MovingLevelGroup
{
    public GameObject[] objectTypes; // Array con tipos de objetos a crear
    public Vector3 spawnBoxSize; // Tamaño de la caja en la que se crean los objetos
    public Vector3 maxRandomTranslationSpeed; // Velocidad máxima aleatoria al crear el objeto
    public Vector3 maxRandomRotationSpeed; // Rotación máxima aleatoria al crear el objeto
    public int itemCount; // Límite de objetos simulados concurrentemente.
    public float spawnInterval;

    public new void Start()
    {
        registerPositionUpdates();
        StartCoroutine(SpawnObjects());
    }

    protected virtual IEnumerator SpawnObjects()
    {
        foreach (GameObject o in objectTypes)
        {
            while (transform.childCount < itemCount)
            {
                // Crea una instancia del objeto con posición aleatoria
                GameObject instance = Instantiate(o, transform.position + Utilities.RandomVector3(spawnBoxSize), Utilities.RandomAngle());

                // La coloca como hijo del objeto especificado
                instance.transform.SetParent(transform);

                //SetRandomRigidbodyMovement(o.transform);
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    protected void ResetToSpawn(Transform instance)
    {
        instance.position = transform.position + Utilities.RandomVector3(spawnBoxSize);
        instance.rotation = Utilities.RandomAngle();
    }

    protected void SetRandomRigidbodyMovement(Transform instance)
    {
        Rigidbody rb = instance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddTorque(Utilities.RandomVector3(maxRandomRotationSpeed), ForceMode.VelocityChange);
            rb.AddForce(Utilities.RandomVector3(maxRandomTranslationSpeed), ForceMode.VelocityChange);
        }
    }

    /** Recicla las instancias de los asteroides, reseteando sus físicas y devolviéndolos
     * al punto de spawn, en vez de crear otras nuevas. */
    protected override void OnOutOfBounds(Transform t)
    {
        ResetToSpawn(t);
        SetRandomRigidbodyMovement(t);
    }
}
