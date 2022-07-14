using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounterScript : MonoBehaviour
{
    [SerializeField] private int enemiesCount = 10;
    private static int enemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemies = enemiesCount;
        //Debug.Log(enemies);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void EnemyKilled ()
    {
        enemies--;
        if (enemies < 0)
        {
            enemies = 0;
            Debug.Log("You Win");
        }
    }
}
