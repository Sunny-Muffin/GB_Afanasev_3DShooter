using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float gunCoolDown = 0.5f;
    [SerializeField] private float speed = 30f;
    [SerializeField] private GameObject bulletPrefab;

    private float nextBulletTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        var bulletGameObject = Instantiate( bulletPrefab, transform.position, transform.rotation);
        Rigidbody rb = bulletGameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    }
        
    //audioManager.Play("Shot");
    //ParticleSystem.Play();
    //Debug.Log($"x = {gunPoint.transform.rotation.x}, y = {gunPoint.transform.rotation.y}, z = {gunPoint.transform.rotation.z}");
}
