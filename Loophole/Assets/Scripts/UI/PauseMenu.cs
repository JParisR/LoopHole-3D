using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; //Objeto menú
    private static bool gameIsPaused = false; //Estado del juego (Corriendo / parado)

   //Comprueba se la tecla "esc" ha sido pulsada
    void Update()
    {
        //Si el juego está parado, lo reanudamos
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
            Resume();
        else if (Input.GetKeyDown(KeyCode.Escape))
           Pause();
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

}
