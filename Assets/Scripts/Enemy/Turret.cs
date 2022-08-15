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
    private Transform player;
    private Animator animator;


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
            //StartCoroutine(PlayAnim());
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(rotation);
    }

    IEnumerator PlayAnim()
    {
        animator.SetBool("isShooting", true);
        yield return new WaitForSeconds(turretCoolDown);
        animator.SetBool("isShooting", false);
    }    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Shoot();
            LookAtPlayer();
        }
    }
}
