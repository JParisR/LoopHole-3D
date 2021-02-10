using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransparencyInstance : MonoBehaviour
{
    public float fadeSpeed = 1;
    private bool fadeIn = true;
    private float alpha = 0;
    private Color c;

    void Start()
    {
        c = GetComponent<Renderer>().material.color;
        setTransparency();
    }

    private void Update()
    {
        if (fadeIn)
        {
            alpha = alpha + (fadeSpeed * Time.deltaTime);
            setTransparency();
            if (alpha >= 1)
            {
                alpha = 1;
                setTransparency();
                fadeIn = false;
            }
        }
    }

    private void setTransparency()
    {
        c = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, alpha);
    }
}
