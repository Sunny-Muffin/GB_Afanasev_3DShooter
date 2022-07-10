using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float gunCoolDown = 0.5f;
    [SerializeField] private float nextBulletTime;
    public float speed = 10f;
    public Vector3 dir;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform aim;

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
            //var bullet = Instantiate(bulletPrefab, gunPoint.transform, false);
            nextBulletTime = Time.time + gunCoolDown;
            //Destroy(bullet.gameObject, bulletLifeTime);
        }
        gunPoint.transform.LookAt(aim);
    }

    private void Shoot()
    {
        dir = new Vector3(gunPoint.transform.rotation.x, gunPoint.transform.rotation.y, gunPoint.transform.rotation.z);
        var bulletGameObject = Instantiate( bulletPrefab, gunPoint.position, gunPoint.rotation);
        bulletGameObject.transform.LookAt(aim);
        if(bulletGameObject.GetComponent<BulletScript>() == true)
        {
            Debug.Log("Script exists!");
            bulletGameObject.GetComponent<BulletScript>().Launch(dir);
        }
        
        //audioManager.Play("Shot");
        //ParticleSystem.Play();
        //Debug.Log($"x = {gunPoint.transform.rotation.x}, y = {gunPoint.transform.rotation.y}, z = {gunPoint.transform.rotation.z}");
    }
}
