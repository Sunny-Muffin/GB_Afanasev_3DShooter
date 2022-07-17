using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float explosionDamage;
    [SerializeField] private float explosionTime = 2f;
    [SerializeField] private AudioClip explosionSound;
    private List<GameObject> gameObjects = new List<GameObject>();

    public void Boom ()
    {
        var exp = Instantiate(explosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        ExplosionDamage(explosionDamage);
        Destroy(gameObject);
        Destroy(exp, explosionTime);
    }

    private void ExplosionDamage (float damage)
    {
        foreach (var obj in gameObjects)
        {
            obj.GetComponent<HealthManager>().Hit(damage);
            //Debug.Log(obj.name);
        }
        //Debug.Log("BOOOM!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthManager health))
        {
            foreach (var obj in gameObjects)
            {
                if (obj.name == other.name)
                    return;
            }
            gameObjects.Add(other.gameObject);
            //Debug.Log($"{other.gameObject.name} added to list");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out HealthManager health))
        {
            gameObjects.Remove(other.gameObject);
            //Debug.Log($"{other.gameObject.name} removed from list");
        }
    }
}
