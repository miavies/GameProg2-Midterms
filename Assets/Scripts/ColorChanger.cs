using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public Color[]colors;
    public int colorIndex;
    public Renderer colorPlayer;
    public Renderer colorFireballFront;
    public Renderer colorFireballTail;
    public Renderer colorBullet;
    // Start is called before the first frame update
    void Start()
    {
        colorIndex = 0;
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            colorIndex++;
            if (colorIndex >= colors.Length) 
            {
                colorIndex = 0;
            }
            UpdateColor();
        }
        if (Input.GetMouseButtonDown(0))
        {
            colorIndex--;
            if (colorIndex < 0)
            {
                colorIndex = colors.Length-1;
            }
            UpdateColor();
        }
    }

    void UpdateColor()
    {
        colorPlayer.material.color = colors[colorIndex];
        colorFireballFront.material.color = colors[colorIndex];
        colorFireballTail.material.color = colors[colorIndex];
        colorBullet.material.color = colors[colorIndex];
    }
}
