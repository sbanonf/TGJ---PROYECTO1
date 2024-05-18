using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : Collectibles
{
    public int cantv;
    public PlayerMovement pm;
    public float tiempo;
    public bool canPower = true;
    
    protected override void Collect(GameObject player)
    {
        if (player.GetComponent<PlayerMovement>().canRun)
        {
            return;
        }
        if (canPower)
        {
            pm = player.GetComponent<PlayerMovement>();
            player.GetComponent<PlayerMovement>().canRun = true;    
            float veloc = pm.speed;
            veloc += cantv;
            pm.speed = veloc;
            StartCoroutine(Timer2());

        }

        
    }

    public IEnumerator Timer2()
    {
        canPower = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSecondsRealtime(tiempo);
        pm.GetComponent<PlayerMovement>().canRun = false;
        pm.speed -= cantv;
        Destroy(this.gameObject);
    }

}
