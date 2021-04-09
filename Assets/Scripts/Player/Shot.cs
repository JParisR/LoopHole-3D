using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject shot; //Objeto misil
    public Transform shotSpawn;//Punto de creación misil
    public float shootRate; //Ratio disparos
    public int destroyTime; //Tiempo hasta destrucción
    
    private GameObject shotReturned; //Objeto misil creado
    private float nextShoot; //Tiempo hasta siguiente disparo

    //Comprueba tecla "espacio" pulsada y ratio de disparos
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootRate; //Ratio de disparo
            shotReturned = Instantiate(shot, shotSpawn.position, Quaternion.identity); //Crea un nuevo misil
        }

        Destroy(shotReturned, destroyTime);
    }
}

