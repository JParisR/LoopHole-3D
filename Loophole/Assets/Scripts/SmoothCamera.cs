using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {

    public Transform player;
    public Vector3 cameraDistance = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position + cameraDistance, ref velocity, 1);
        }
    }
}
