using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : Collectibles
{
    public int cantv;
    public PlayerMovement playerMovement;
    public float tiempo;
    public bool canPower = true;

    void Start(){
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    
    protected override void Collect()
    {
        if (playerMovement.canRun)
        {
            return;
        }
        if (canPower)
        {
            audioManager.instance.Play("beber");
            playerMovement.canRun = true;    
            float veloc = playerMovement.speed;
            veloc += cantv;
            playerMovement.speed = veloc;
            StartCoroutine(Timer2());

        }

        
    }

    public IEnumerator Timer2()
    {
        canPower = false;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        yield return new WaitForSecondsRealtime(tiempo);
        playerMovement.canRun = false;
        playerMovement.speed -= cantv;
        Destroy(this.gameObject);
    }

}
