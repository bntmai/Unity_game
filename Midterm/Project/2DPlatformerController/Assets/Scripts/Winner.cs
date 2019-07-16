using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
	public Text WinnerText;
	void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
        	WinnerText.text = WinnerText.text + "\nMark: " + collision.GetComponent<MarkGold>().mark.ToString();
      
        	WinnerText.enabled = true;
    	}
    }
}
