using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    [SerializeField] private float lifetime = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector3 dir)
    {
        Debug.Log("Launch!");
        //rb.velocity = dir * speed;
        rb.AddForce(dir.x * force, dir.y * force, dir.z * force, ForceMode.Impulse);
        //transform.localScale = new Vector3(Mathf.Sign(dir.x) * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Destroy(gameObject, lifetime);
        Debug.Log("End Launch!");
    }
}
