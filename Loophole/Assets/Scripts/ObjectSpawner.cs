using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] asteroidTypes;
    public Vector3 spawnBoxSize;
    public Vector3 initialSpeed;
    public Vector3 minimumSpeed;
    public Vector3 maxRandomTranslationSpeed;
    public Vector3 maxRandomRotationSpeed;
    public float despawnDistance;
    public int itemCount;

    private int spawnedObjects = 0;

    void FixedUpdate()
    {
        if (spawnedObjects < itemCount)
        {
            foreach (GameObject o in asteroidTypes)
            {
                if (spawnedObjects < itemCount)
                {
                    GameObject instance = Instantiate(o, transform.position + randomVector3(spawnBoxSize), randomRotation());

                    instance.transform.SetParent(transform);
                    Rigidbody rb = instance.GetComponent<Rigidbody>();

                    rb.AddTorque(randomVector3(maxRandomRotationSpeed), ForceMode.VelocityChange);
                    rb.AddForce(initialSpeed + randomVector3(maxRandomTranslationSpeed), ForceMode.VelocityChange);

                    spawnedObjects++;
                }
            }
        }
        foreach (Transform child in transform)
        {
            //TODO: Inhabilitar físicas rigidbody, luego mover vector de posición del objeto y por último llamar a update de rigidbody.
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if ((Vector3.Angle(rb.velocity, initialSpeed) > 45) && (Vector3.SqrMagnitude(rb.velocity) < Vector3.SqrMagnitude(initialSpeed)))
            {
                rb.AddForce(initialSpeed, ForceMode.VelocityChange);
            }
            if (child.position.magnitude - transform.position.magnitude > despawnDistance)
            {
                Destroy(child.gameObject);
                spawnedObjects--;
            }
        }
    }

    private Vector3 randomVector3(Vector3 limit)
    {
        return new Vector3(
                            Random.Range(-limit.x, limit.x),
                            Random.Range(-limit.y, limit.y),
                            Random.Range(-limit.z, limit.z)
                        );
    }

    private Quaternion randomRotation()
    {
        return Quaternion.Euler(
                            Random.Range(0, 360),
                            Random.Range(0, 360),
                            Random.Range(0, 360)
                        );
    }
}
