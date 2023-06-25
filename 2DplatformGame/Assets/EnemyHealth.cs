using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private static int health = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("spikeBall"))
        {
            health--;
            Debug.Log(health);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
           
        }
    }
}
