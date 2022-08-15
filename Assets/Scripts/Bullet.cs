using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 20f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private float speed = 20f;
    [SerializeField] private bool isTurret = false;
    [SerializeField] private string shooterTag;

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
        Hit(collision.gameObject);
    }

    private void Hit(GameObject collisionGO)
    {
        if (!collisionGO.CompareTag(shooterTag) && collisionGO.TryGetComponent(out HealthManager health))
        {
            //Debug.Log(collisionGO.gameObject.name);
            // вот тут проблема: пули наносят урон игроку
            // надо разделить пули врага и пули игрока
            health.Hit(damage);
        }
        // звук столкновения
        // эффект от столкновения
        Destroy(gameObject);
    }
}
