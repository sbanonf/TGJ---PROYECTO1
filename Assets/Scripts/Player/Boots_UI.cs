using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots_UI : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject playerVida;
    public GameObject playerVida1;
    public GameObject playerVida2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.useBoot)
        {
            playerVida.SetActive(true);
        }
        else
        {
            playerVida.SetActive(false);
        }

        if (player.canRun)
        {
            playerVida1.SetActive(true);
        }
        else
        {
            playerVida1.SetActive(false);
        }

        if (player.timeOut)
        {
            playerVida2.SetActive(true);
        }
        else
        {
            playerVida2.SetActive(false);
        }
    }
}
