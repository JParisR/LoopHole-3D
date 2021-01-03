using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float shootRate;

    public int destroyTime;
    GameObject shotReturned;
    private float nextShoot;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootRate; //Ratio de disparo
            shotReturned = Instantiate(shot, shotSpawn.position, Quaternion.identity);

        }
        Destroy(shotReturned, destroyTime);
    }
}

