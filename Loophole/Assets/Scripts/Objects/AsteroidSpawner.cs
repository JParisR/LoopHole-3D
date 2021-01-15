using System.Collections;
using UnityEngine;

public class AsteroidSpawner : ObjectSpawner
{
    public bool enemyObjects;

    protected override IEnumerator SpawnObjects()
    {
        while (transform.childCount < itemCount)
        {
            foreach (GameObject o in objectTypes)
            {
                GameObject instance = Instantiate(o, transform.position + Utilities.RandomVector3(spawnBoxSize), Utilities.RandomAngle());
                instance.transform.SetParent(transform);

                if (enemyObjects == true)
                {
                    instance.layer = 9;
                    foreach (Transform trans in instance.GetComponentsInChildren<Transform>(true))
                    {
                        trans.gameObject.layer = 9;
                    }
                }

                //SetRandomRigidbodyMovement(o.transform);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
