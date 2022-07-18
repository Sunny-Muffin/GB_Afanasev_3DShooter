using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioClip shootSound;

    [SerializeField] private float turretCoolDown = 1.5f;
    [SerializeField] private float angularSpeed = 0.5f;

    private float nextBulletTime;
    private Transform player;


    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().transform;
    }

    private void Shoot()
    {
        if (Time.time > nextBulletTime)
        {
            muzzleFlash.Play();
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            AudioSource.PlayClipAtPoint(shootSound, transform.position); // ??
            nextBulletTime = Time.time + turretCoolDown;
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(rotation);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Somethig in trigger");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player in trigger");
            Shoot();
            LookAtPlayer();
        }
    }
}
