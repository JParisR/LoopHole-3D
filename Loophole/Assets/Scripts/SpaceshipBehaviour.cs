using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehaviour : MonoBehaviour
{
    public Rigidbody rb;

    public float movement_factor = 200;
    public float rotation_factor = 200;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
        FixedUpdate is called with the frequency of the physics system
        (totally independent of frame-rate operations)
        https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
    */
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(movement_factor * Time.deltaTime * Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(movement_factor * Time.deltaTime * Vector3.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(movement_factor * Time.deltaTime * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(movement_factor * Time.deltaTime * Vector3.back);
        }
        if (Input.GetKey(KeyCode.R))
        {
            rb.AddForce(movement_factor * Time.deltaTime * Vector3.up);
        }
        if (Input.GetKey(KeyCode.F))
        {
            rb.AddForce(movement_factor * Time.deltaTime * Vector3.down);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(rotation_factor * Time.deltaTime * Vector3.up);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddTorque(rotation_factor * Time.deltaTime * Vector3.down);
        }
    }
}
