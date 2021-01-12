using UnityEngine;

public class MissileSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float speed = 80;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }
}
