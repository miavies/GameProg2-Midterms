using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyColorIndex; 
    public float moveSpeed;
    private Transform player; 
    public event Action OnDestroyed;

    void Start()
    {
        // Find the player GameObject and get its Transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveSpeed = 2f;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    void OnDestroy()
    {
        // Invoke the event
        OnDestroyed?.Invoke();
    }
}
