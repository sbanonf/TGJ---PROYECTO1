using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public bool isGameFinished = false;
    public bool CorreTiempo = false;
    [SerializeField] public int TurnoIndex;
    [SerializeField] public int NumeroTurnos;

    public float tiempoxTurno = 40;
    public float tiempoRuntime = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }
    
    private void Start()
    {
        EmpezarTurno();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Mercado" || SceneManager.GetActiveScene().name == "PruebasRestaurante") {
            if (!isGameFinished)
            {
                if (CorreTiempo)
                {
                    if (tiempoRuntime > 0)
                    {
                        tiempoRuntime -= Time.deltaTime;
                    }
                    else
                    {
                        tiempoRuntime = 0;
                        FinTurno();
                    }
                }
            }
            // else if (SceneManager.GetActiveScene().name != "WinGame")
            // {
            //     Debug.Log("Fin del Juego");
            //     Resetear();
            //     if (SceneManager.GetActiveScene().name != "GameOver")
            //         SceneManager.LoadScene("GameOver");
            // }
        }
    }

    public void FinTurno() {
        if (TurnoIndex < NumeroTurnos)
        {
            //Cambia de Escena XD
            if (SceneManager.GetActiveScene().name == "Mercado")
            {
                SceneManager.LoadScene("PruebasRestaurante");
                EmpezarTurnoRestaurante();
            }
            else if (SceneManager.GetActiveScene().name == "PruebasRestaurante")
            {
                SceneManager.LoadScene("Mercado");
                EmpezarTurno();
            }
        }
        else
        {
            Debug.Log("Fin del Juego");
            SetGameOver();
        }
    }
    public void EmpezarTurno() {
        CorreTiempo = true;
        tiempoRuntime = tiempoxTurno;
    }

    public void EmpezarTurnoRestaurante() {
        CorreTiempo = false;
        TurnoIndex++;
    }
    public void SetGameOver() {
        isGameFinished = true;
        if(PuntuacionManager.Instance.pass)
            SceneManager.LoadScene("WinGame");
        else{
            SceneManager.LoadScene("GameOver");
        }
        Resetear();  
    }

    public void Resetear()
    {
        isGameFinished = false;
        CorreTiempo = false;
        tiempoRuntime = 40;
        TurnoIndex = 0;
    }
}
