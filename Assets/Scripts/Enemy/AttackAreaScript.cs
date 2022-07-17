using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaScript : MonoBehaviour
{
    [SerializeField] private float hitCoolDown = 1f;
    private float nextHitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Time.time > nextHitTime)
            {
                //Debug.Log("Hit player!");
                nextHitTime = Time.time + hitCoolDown;
                // создать скрипт здоровья игрока, вызывать его здесь
            }
        }
    }
}
