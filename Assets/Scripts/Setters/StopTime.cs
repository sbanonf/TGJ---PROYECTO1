using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : Collectibles
{
    public float waittime;
    public PlayerMovement playerMovement;
    public bool canPower = true;

    void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    
    protected override void Collect()
    {
        if (playerMovement.timeOut)
        {
            return;
        }
        if (canPower) {
            audioManager.Instance.Play("halls");
            TimeManager.instance.CorreTiempo = false;
            playerMovement.timeOut = true;
            StartCoroutine(Timer2());
        }
        
    }
    public IEnumerator Timer2()
    {
        canPower = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(waittime);
        playerMovement.timeOut = false;
        TimeManager.instance.CorreTiempo = true;
        Destroy(gameObject);
    }

}
