using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public String gameScene;

    //Cargamos primer nivel del juego
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
        PlayerPrefs.SetString("escena",gameScene);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("escena"));
    }

    //Método para volver al menú principal
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuScene");
        PlayerPrefs.SetString("escena", "EarthMoon");
        Time.timeScale = 1f;
    }

    //Salimos del juego
    public void QuitGame()
    {
        Application.Quit();
    }

}
