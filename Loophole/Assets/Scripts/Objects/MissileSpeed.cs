using UnityEngine;

public class MissileSpeed : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 80; //Velocidad del misil

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Movimiento del misil
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }
}
