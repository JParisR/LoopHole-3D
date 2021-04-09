using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
    public GameObject shot; //Objeto misil
    public Transform shotSpawn; //Punto de aparición del misil
    public GameObject enemyShip; //Objeto nave
    public GameObject explosionEfects; //Efecto de explosión
    public float timeBetwenShoots; //Tiempo entre disparos
    public int destroyTime;
    public AudioSource explosionSound; //Sonido al destruirse

    private GameObject shotReturned; //Objeto bala creada
    private float timetoShot; //Tiempo hasta próximo disparo
    private bool spaceDestroyed = false; //Estado de la nave

    /*
    private void Start()
    {
        explosionSound = GetComponent<AudioSource>();
    }*/

    // Update is called once per frame
    void Update()
    {   //Comprueba si la nave puede disparar
        if (spaceDestroyed == false && timetoShot <= 0)
        {
            shotReturned = Instantiate(shot, shotSpawn.position, Quaternion.identity); //Crea un nuevo misil
            timetoShot = timeBetwenShoots; //Restablece el tiempo entre disparos

        }
        else
        {//Calcula el tiempo restante para disparar
            timetoShot -= Time.deltaTime;
        }

        Destroy(shotReturned, destroyTime);

    }

    //Colisiones con la nave
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            spaceDestroyed = true; //Estado destruido -> No puede disparar
            explosionEfects.SetActive(true); //Activa efectos de explosión
            if (explosionSound != null)
            {
                //explosionSound.transform.parent = null;
                //AudioSource.PlayClipAtPoint(explosionSound.clip, transform.position);
                explosionSound.Play();
                //Destroy(explosionSound, explosionSound.clip.length);
            }
            Invoke("DestroyShip", 0.7f); //Delay para despawnear la nave
        }
        // Aquí solo tendría que hacer RaiseScore si se ha destruido por un impacto con un meteorito 
        // o un impacto con un disparo nuestro. 
        // En caso de que colisione con la nave del jugador tendría que lanzar un TakeDamage al jugador
        
        if (collision.gameObject.name.Contains("missile(Clone)"))
        {
            // sacar esto fuera y dejar solo raise
            SpaceshipBehaviour playerStats = GameObject.Find("Player Spaceship").GetComponent<SpaceshipBehaviour>();
            playerStats.RaiseScore(1);
        }
        

    }

    //Función que destruye una nave enemiga
    void DestroyShip()
    {
        Destroy(enemyShip);
    }
}