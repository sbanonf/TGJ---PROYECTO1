using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public TextMeshProUGUI tmpro;
    public bool isGameFinished = false;
    public bool CorreTiempo = false;
    [SerializeField] public int TurnoIndex;
    [SerializeField] public int NumeroTurnos;

    public float tiempoxTurno = 40;
    public float tiempoRuntime = 0;

    private void Awake()
    {
        if (instance == null)
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
        if (!isGameFinished)
        {
            if (CorreTiempo) {
                if (tiempoRuntime > 0)
                {
                    tiempoRuntime -= Time.deltaTime;
                    tmpro.text = Math.Round(tiempoRuntime).ToString();
                }
                else
                {
                    tiempoRuntime = 0;
                    tmpro.text = Math.Round(tiempoRuntime).ToString();
                    EmpezarTurno();
                }
            }            
        }
    }
    public void EmpezarTurno() {
        CorreTiempo = true;
        TurnoIndex++;
        tiempoRuntime = tiempoxTurno;
        if (TurnoIndex < NumeroTurnos)
        {

        }
        else {
            Debug.Log("Fin del Juego");
            SetGameOver();
        }
    }
    public void SetGameOver() { 
        isGameFinished = true; ;
        //SceneManager.LoadScene("FinalBueno");
    }
}
