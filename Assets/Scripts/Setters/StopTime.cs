using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : Collectibles
{
    public float waittime;
    public bool canPower = true;
    protected override void Collect(GameObject player)
    {
        if (canPower) {
            TimeManager.instance.CorreTiempo = false;
            StartCoroutine(Timer2());
        }
        
    }
    public IEnumerator Timer2()
    {
        canPower = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(waittime);
        TimeManager.instance.CorreTiempo = true;
        Destroy(this.gameObject);
    }

}
