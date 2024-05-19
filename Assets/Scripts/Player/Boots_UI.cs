using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots_UI : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject playerVida;
    public GameObject playerVida1;
    public GameObject playerVida2;

    // Update is called once per frame
    void Update()
    {
        playerVida.SetActive(player.useBoot);

        playerVida1.SetActive(player.canRun);

        playerVida2.SetActive(player.timeOut);
    }
}
