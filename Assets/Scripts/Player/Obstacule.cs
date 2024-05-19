using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Obstacule : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public CinemachineVirtualCamera cm1;
    public CinemachineVirtualCamera cm2;

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
                audioManager.Instance.Play("charco");
                playerMovement.canMove = false;
                cm1.Priority = 9;
                cm2.Priority = 11;
                
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
        cm1.Priority = 11;
        cm2.Priority = 9;
        playerMovement.canMove = true;
    }

}
