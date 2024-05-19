using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class BootItem : Collectibles
{
    public float tiempo;
    public bool canWalk = true;
    public PlayerMovement playerMovement;
    public CinemachineVirtualCamera cm1;
    public CinemachineVirtualCamera cm2;

    void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    protected override void Collect()
    {
        if (playerMovement.useBoot)
        {
            return;
        }
        if (canWalk)
        {
            audioManager.instance.Play("coger");
            playerMovement.useBoot = true;
            cm1.Priority = 11;
            cm2.Priority = 9;
            StartCoroutine(Timer2());
        }
    }

    public IEnumerator Timer2()
    {
        canWalk = false;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        yield return new WaitForSecondsRealtime(tiempo);
        Destroy(this.gameObject);
    }

}
