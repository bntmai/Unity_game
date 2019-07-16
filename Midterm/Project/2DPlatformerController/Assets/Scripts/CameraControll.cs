using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public GameObject player;
    private Vector3 playerPosition;
    public float offset;
    public float offsetSmoothing;
    // Use this for initialization
    void Start()
    {
        //Debug.Log(player.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f)
        {
           
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }  
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);


    	playerPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        if (player.transform.localScale.y > 0f)
        {
           
            playerPosition = new Vector3(playerPosition.x, playerPosition.y + offset, playerPosition.z);
        }  
        else
        {
            playerPosition = new Vector3(playerPosition.x, playerPosition.y - offset, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);

	
    }
}
