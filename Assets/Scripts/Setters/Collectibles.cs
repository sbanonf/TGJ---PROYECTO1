using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colision� tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Collect();
        }   

    }

    protected abstract void Collect();

}
