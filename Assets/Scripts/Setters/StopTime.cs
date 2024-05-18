using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : Collectibles
{
    public float waittime;
    public PlayerMovement pm;
    public bool canPower = true;
    protected override void Collect(GameObject player)
    {
        if (player.GetComponent<PlayerMovement>().timeOut)
        {
            return;
        }
        if (canPower) {
            TimeManager.instance.CorreTiempo = false;
            player.GetComponent<PlayerMovement>().timeOut = true;
            StartCoroutine(Timer2());
        }
        
    }
    public IEnumerator Timer2()
    {
        canPower = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(waittime);
        pm.GetComponent<PlayerMovement>().timeOut = false;
        TimeManager.instance.CorreTiempo = true;
        Destroy(this.gameObject);
    }

}
