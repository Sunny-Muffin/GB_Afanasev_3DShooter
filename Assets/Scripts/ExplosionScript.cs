using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private int barrelHP = 3;
    [SerializeField] private ParticleSystem explosion;
    private static bool boom = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            barrelHP--;
            Destroy(collision.gameObject); // � ���� ��? ����������� ���������
            if (barrelHP < 0)
            {
                barrelHP = 0;
                Instantiate(explosion, transform.position, Quaternion.identity);
                boom = true;
                // sound
                Destroy(gameObject);
            }
        }
    }

    static void OnTriggerEnter(Collider other)
    {
        // �� ��������!!!, ���� �� �������� ��� ����������� ���� �� ������
        if (boom == true)
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
            {
                // � ���� �� ����� ������ ������ ��������?..
                // ����� ����� ���������� � �������� ��������, ������� ���� ���
                Destroy(other.gameObject);
            }
        }
    }
}
