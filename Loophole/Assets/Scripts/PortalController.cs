using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed));         
        
    }

    void OnTriggerEnter (Collider collider)
    {
        if (collider.name != "Player Spaceship")        
        {
            Destroy(collider);
        }
    }


    public void dropSpeed(int s)
    {
        speed = s;
    }
}
