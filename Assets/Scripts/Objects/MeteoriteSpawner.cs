using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    private float timer;
    public GameObject[] Meteoritos = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            float x = Random.Range(-30f,30f);
            float y = Random.Range(-30f,30f);
            int i = Random.Range(0,3);
            Vector3 position = new Vector3(x, y, 30);
            Quaternion rotation = new Quaternion();
            //Debug.Log("instancia " + i.ToString());
            Instantiate(Meteoritos[i], position, rotation);

            timer = 0;
        }
        
    }
}
