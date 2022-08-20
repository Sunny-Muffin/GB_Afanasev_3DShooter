using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioClip shootSound;

    [SerializeField] private float turretCoolDown = 1.5f;
    [SerializeField] private float angularSpeed = 0.5f;

    private float nextBulletTime;
    private bool isShooting = false;
    private Transform player;
    private Animator animator;


    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().transform;
        animator = GetComponentInChildren<Animator>();
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        animator.Play("TurretShooting");
        muzzleFlash.Play();
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        AudioSource.PlayClipAtPoint(shootSound, transform.position); // ??
        yield return new WaitForSeconds(turretCoolDown);
        isShooting = false;
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(rotation);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Shoot();
            LookAtPlayer();
            if (!isShooting)
                StartCoroutine(Shoot());
        }
    }
}
