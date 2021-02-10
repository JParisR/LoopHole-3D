using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleScore : MonoBehaviour
{
    public Text scoreMarcador;
    public SpaceshipBehaviour playerScore;

    // Start is called before the first frame update
    void Start()
    {
         playerScore = GameObject.Find("Player Spaceship").GetComponent<SpaceshipBehaviour>();       
    }


    // Update is called once per frame
    void Update()
    {
        scoreMarcador.text = playerScore.score.ToString();
       
    }
}
