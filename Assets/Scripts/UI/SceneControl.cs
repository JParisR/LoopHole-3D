using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    int sceneBuildIndex;

    private void OnTriggerEnter(Collider other)
    {
        //Cuando el jugador finaliza el nivel, avanza a la siguiente escena
        if (other.gameObject.name == "Player Spaceship")
        {
            sceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(sceneBuildIndex);
            PlayerPrefs.SetString("escena", SceneUtility.GetScenePathByBuildIndex(sceneBuildIndex));
        }
            

    }

}
