using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject shot;
    GameObject shotReturned;
    public Transform shotSpawn;
    public float shootRate;
    private float nextShoot;
    public float shootSpeed;
    public int destroyTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootRate;
            shotReturned = Instantiate(shot, shotSpawn.position, Quaternion.identity);

        }
        shotReturned.GetComponent<Rigidbody>().AddForce(Vector3.forward * shootSpeed);
        Destroy(shotReturned, destroyTime);
    }
}

