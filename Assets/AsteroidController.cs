using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    void OnTriggerExit(Collider colllision)
    {
        Destroy(gameObject);
    }
}
