using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    public float speed;
    public ParticleSystem HitEffect;

    void Start()
    {
    }
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed)); 
    }
    void OnCollisionEnter (Collision collision)
    {
        GameObject thecollision = collision.gameObject;
        //Debug.Log(thecollision.name);
        /*
        if (thecollision.name == "fondo")
        {
            //Debug.Log("destruir objeto");
            Destroy(gameObject);
        }
        else
        */ 
        if (thecollision.name == "Player Spaceship")
        {
            Debug.Log("impacto");
            SpaceshipBehaviour playerStats = GameObject.Find("Player Spaceship").GetComponent<SpaceshipBehaviour>();
            playerStats.TakeDamage(1);
            HitEffect.Play();  
        }
        else
        {
            HitEffect.Play();  
        }

    }
}
