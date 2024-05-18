using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colisionó tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect(collision.gameObject);
        }   

    }

    protected abstract void Collect(GameObject player);

}
