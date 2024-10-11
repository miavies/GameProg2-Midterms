using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform spawnPoint;     
    public float bulletRotation;     
    public ColorChanger colorChanger;
    public float invokeTime;
    public float repeatRate;
    public float speedAnim;
    void Start()
    {
        speedAnim = 3f;
        invokeTime =  2.08f/speedAnim;
        repeatRate = 3.37f/speedAnim;
        InvokeRepeating("ShootBullet", invokeTime, repeatRate);
    }

    void ShootBullet()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.Euler(0f, bulletRotation, 0f));
        bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        bullet.transform.localRotation = spawnPoint.rotation;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null && colorChanger != null)
        {
            Color color = colorChanger.colors[colorChanger.colorIndex];
            int index = colorChanger.colorIndex; 

            bulletScript.InitializeBulletColor(color, index);
        }
    }
}
