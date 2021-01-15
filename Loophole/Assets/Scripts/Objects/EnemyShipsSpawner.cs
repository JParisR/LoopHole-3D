using UnityEngine;

public class EnemyShipsSpawner : ObjectSpawner
{
    //public int itemCount = 5;
    public float timeWait = 1;
    private float timeBetwenShoots;
    public GameObject explosionEfects;

    void FixedUpdate()
    {
        if (timeBetwenShoots <= 0)
        {
            timeBetwenShoots = timeWait;
        }
        else
        {
            timeBetwenShoots -= Time.deltaTime;
        }
    }
}