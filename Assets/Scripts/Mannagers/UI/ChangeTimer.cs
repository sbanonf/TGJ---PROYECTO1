using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTimer : MonoBehaviour
{
    public float tiempoRuntime = 0;
    public float tiempoxTurno = 40;
    // Start is called before the first frame update
    void Start()
    {
        tiempoRuntime = tiempoxTurno;
    }

    // Update is called once per frame
    void Update()
    {

        if (tiempoRuntime > 0)
        {
            tiempoRuntime -= Time.deltaTime;
        }
        else
        {
            tiempoRuntime = 0;
            Resetear();
        }
        
    }

    public void Resetear()
    {
        SceneManager.LoadScene("Mercado");

    }

}
