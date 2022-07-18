using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"{collision.gameObject.name} steped on mine");
        if (collision.gameObject.TryGetComponent(out HealthManager health))
        {
            //Debug.Log($"{collision.gameObject.name} has health script");
            gameObject.GetComponent<ExplosionScript>().Boom();
        }
    }
}
