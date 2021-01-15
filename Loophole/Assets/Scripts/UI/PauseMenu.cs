using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public SpaceshipBehaviour playerHealth;
    public GameObject pauseMenuUI; //Objeto menú
    public Scene gameOverMenuUI; //Objeto menú gameOver
    private static bool gameIsPaused = false; //Estado del juego (Corriendo / parado)

    void Start()
    {
        playerHealth = GameObject.Find("Player Spaceship").GetComponent<SpaceshipBehaviour>();
    }

    //Comprueba se la tecla "esc" ha sido pulsada
    void Update()
    {
        if(playerHealth.health <= 0)
        {
            LoadGameOverScene();
        }
        //Si el juego está parado, lo reanudamos
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
           
    }

    //Método para reanudar el juego
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    //Método para entrar en el menú de pausa
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //Detenemos el tiempo
        gameIsPaused = true;
    }

    //Método para volver al menú principal
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }

    //Carga la escena GameOver
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
