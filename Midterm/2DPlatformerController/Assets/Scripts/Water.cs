using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   public int mana;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
             collision.GetComponent<HealthController>().addMana(mana);
             Destroy(gameObject);
        }
    }
}
