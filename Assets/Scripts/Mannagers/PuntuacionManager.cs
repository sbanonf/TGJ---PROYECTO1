using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntuacionManager : Singleton<PuntuacionManager>
{
    public int PuntuacionCount;
    public int incremento;
    static public bool pass = true;
    public int MetaPuntuacion;

    public void FinDelTurno() {
        Debug.Log("Fin turno");
        Debug.Log(PuntuacionCount);
        if (PuntuacionCount >= MetaPuntuacion)
        {
            Debug.Log("Tengo puntaje necesario");
            Debug.Log(PuntuacionCount);
            pass = true;
            MetaPuntuacion += incremento;
            incremento += 2;
            PuntuacionCount = 0;
            TimeManager.instance.CorreTiempo = true;
        }
        else {
            TimeManager.instance.isGameFinished = true;
            pass = false;
        }
 
        TimeManager.instance.FinTurno();
    }

    public void PuntuacionFinal() {
        var dictionary = RecipeManager.Instance.PlayerRecetas;
        foreach (var item in dictionary)
        {
            Debug.Log(item.Key + ": " + item.Value + ":"+ item.Key.puntos);
            PuntuacionCount += item.Key.puntos * item.Value;
        }
        FinDelTurno();
    }

    public void Reset() {
        PuntuacionCount = 0;
        MetaPuntuacion = 10;
        incremento = 2;
        pass = true;
        TimeManager.instance.CorreTiempo = true;
        TimeManager.instance.isGameFinished = false;
    }

}
