using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //[SerializeField] private float force = 10f;
    [SerializeField] private float lifetime = 2f;

    private Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
