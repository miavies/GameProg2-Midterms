using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan;
    public float moveSpeed;
    public Renderer colorFireballFront;
    public Renderer colorFireballTail;
    private Color bulletColor;
    public int bulletColorIndex;

    public void InitializeBulletColor(Color color, int colorIndex)
    {
        lifespan = 8f;
        bulletColor = color;
        bulletColorIndex = colorIndex;
        UpdateColor();
    }
    void Start()
    {
        moveSpeed = 5f;
    }

    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        lifespan -= Time.deltaTime;

        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateColor()
    {
        colorFireballFront.material.color = bulletColor;
        colorFireballTail.material.color = bulletColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null && bulletColorIndex == enemy.enemyColorIndex)
            {
                Destroy(collision.gameObject); 
            }
        }
        Destroy(gameObject); 
    }
}
