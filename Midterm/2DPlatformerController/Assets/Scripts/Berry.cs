using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
   public int health;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
             collision.GetComponent<HealthController>().addHeath(health);
             Destroy(gameObject);
        }
    }
}
