using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class BootItem : Collectibles
{
    public float tiempo;
    public bool canWalk = true;
    public PlayerMovement pm;
    public CinemachineVirtualCamera cm1;
    public CinemachineVirtualCamera cm2;

    protected override void Collect(GameObject player)
    {
        if (player.GetComponent<PlayerMovement>().useBoot)
        {
            return;
        }
        if (canWalk)
        {
            pm = player.GetComponent<PlayerMovement>();
            pm.useBoot = true;
            cm1.Priority = 11;
            cm2.Priority = 9;
            StartCoroutine(Timer2());
        }
    }

    public IEnumerator Timer2()
    {
        canWalk = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSecondsRealtime(tiempo);
        Destroy(this.gameObject);
    }

}
