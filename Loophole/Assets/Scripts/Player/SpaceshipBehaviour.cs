using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipBehaviour : MonoBehaviour
{
    /* Las variables públicas son ajustables desde el inspector de Unity */

    // Movimiento nave
    public float smoothingTime = 1f; // Tiempo de suavizado entre posiciones (segundos)
    public Vector3 leftPosition = Vector3.left * 1f; // Posición al pulsar tecla izquierda
    public Vector3 rightPosition = Vector3.right * 1f; // Posición al pulsar tecla derecha
    public Vector3 topPosition = Vector3.up * 1f; // Posición al pulsar tecla arriba
    public Vector3 bottomPosition = Vector3.down * 1f; // Posición al pulsar tecla abajo
    private Vector3 targetPosition = Vector3.zero; // Posición "destino" a la que se intenta llegar
    private Vector3 velocity = Vector3.zero; // Velocidad actual del suavizado

    // Salud y puntuación
    public int health = 5;
    public int score = 0;

    // Material para animaciones
    public Material mymaterial;

    // Sonido de la nave
    public AudioSource spaceshipSound;

    /** Start se ejecuta justo antes de dibujar el primer fotograma */
    void Start()
    {
        spaceshipSound?.Play();
    }

    /** 
     * Update se llama una vez por fotograma.
     * Aquí se colocan operaciones gráficas.
     */
    void Update()
    {
        // Mueve el jugador con un efecto de suavizado a la posición destino.
        // Velocity se pasa por referencia y contiene la velocidad actual de la operación de suavizado.
        // Se hace esta operación dentro de Update en vez de FixedUpdate porque si no se ve que la nave se mueve "a saltos".
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothingTime);
    }

    /**
     * FixedUpdate se llama con la frecuencia del sistema de físicas,
     * y es totalmente independiente de la tasa de fotogramas.
     * https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
     * Aquí se colocan operaciones de físicas o movimiento.
     */
    void FixedUpdate()
    {
        // Obtiene la posición a la que se quiere mover
        targetPosition = readKeyInput();
    }

    /**
     * Lee la entrada por teclado del jugador y devuelve el vector correspondiente a la dirección seleccionada.
     */
    private Vector3 readKeyInput()
    {
        // Entrada por defecto es cero
        Vector3 input = Vector3.zero;

        /*
         * Si se pulsa alguna tecla, se suma el vector correspondiente a esa dirección.
         * De esta manera si se pulsan varias teclas, se combinan ambas posiciones.
         * Si se da el caso de que se pulsan dos teclas contrarias (p.ej izquierda y derecha)
         * a la vez, la suma de ambas se anula y quedaría en el centro.
         * Esto se debería hacer a través del gestor de entradas de Unity y no aquí directamente,
         * por si el usuario desea remapear las acciones a otros botones.
         * https://docs.unity3d.com/Manual/class-InputManager.html
        */
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            input += leftPosition;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            input += rightPosition;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            input += topPosition;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            input += bottomPosition;

        return input;
    }

    void OnTriggerEnter (Collider collider)
    {
        if (collider.name == "Portal")        
        {
            //GameObject portal = GameObject.Find("Portal");
            //portal.GetComponent<PortalController>().dropSpeed(3);
            GameObject spaceship = GameObject.Find("Player Spaceship");
            MeshRenderer renderer = spaceship.GetComponent<MeshRenderer>();
            renderer.material = mymaterial;
        }
    }

	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("Health = " + health.ToString());
	}

	public void RaiseScore(int unit)
	{
		score += unit;
		Debug.Log("Score = " + score.ToString());
	}

}
