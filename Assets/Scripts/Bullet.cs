using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 20f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private float speed = 20f;
    [SerializeField] private bool isTurret = false;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }


    // Update is called once per frame
    void Update()
    {
        if (isTurret)
            transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Hit(collision.gameObject);
    }

    private void Hit(GameObject collisionGO)
    {
        if (collisionGO.TryGetComponent(out HealthManager health))
        {
            //Debug.Log(collisionGO.gameObject.name);
            // ��� ��� ��������: ���� ������� ���� ������
            // ���� ��������� ���� ����� � ���� ������
            health.Hit(damage);
        }
        // ���� ������������
        // ������ �� ������������
        Destroy(gameObject);
    }
}
