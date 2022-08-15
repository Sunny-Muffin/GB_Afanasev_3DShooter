using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float gunCoolDown = 0.5f;
    [SerializeField] private float speed = 30f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioClip shootSound;

    private float nextBulletTime;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextBulletTime)
        {
            Shoot();
            nextBulletTime = Time.time + gunCoolDown;
        }
    }

    private void Shoot()
    {
        var bulletGameObject = Instantiate( bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = bulletGameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        AudioSource.PlayClipAtPoint(shootSound, transform.position); // ??

        // particle system
    }
}
