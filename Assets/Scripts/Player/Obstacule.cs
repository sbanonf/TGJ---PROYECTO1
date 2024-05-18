using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacule : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ice")
        {
            bool use = playerMovement.useBoot;
            if (use)
            {
                playerMovement.canMove = true;
            }
            else
            {
                playerMovement.canMove = false;
            }
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            playerMovement.useBoot = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerMovement.canMove = true;
    }
}
