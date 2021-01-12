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
    }

    //Salimos del juego
    public void QuitGame()
    {
        Application.Quit();
    }

}
