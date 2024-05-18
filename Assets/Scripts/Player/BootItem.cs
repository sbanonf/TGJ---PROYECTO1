using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootItem : Collectibles
{
    public float tiempo;
    public bool canWalk = true;
    public PlayerMovement pm;
    protected override void Collect(GameObject player)
    {
        if (canWalk)
        {
            pm = player.GetComponent<PlayerMovement>();
            pm.useBoot = true;
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
