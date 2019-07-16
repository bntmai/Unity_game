using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold1 : MonoBehaviour
{
   public int mark;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
             collision.GetComponent<MarkGold>().addMark(mark);
             Destroy(gameObject);
        }
    }
}
