using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleHealth : MonoBehaviour
{
    
    public Slider healthBar;
    public SpaceshipBehaviour playerHealth;

    void Start(){
        playerHealth = GameObject.Find("Player Spaceship").GetComponent<SpaceshipBehaviour>();
        
    }
    void Update(){
        healthBar.value = playerHealth.health;
    }
    
}
