using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntuacionManager : StaticInstance<PuntuacionManager>
{
    public int PuntuacionCount;
    public int incremento;
    public int MetaPuntuacion;
    public static PuntuacionManager instance;

    public void FinDelTurno() {
        if (PuntuacionCount >= MetaPuntuacion)
        {
            MetaPuntuacion += incremento;
            TimeManager.instance.CorreTiempo = true;
        }
        else {
            TimeManager.instance.isGameFinished = true;
        }
 
        TimeManager.instance.FinTurno();
    }

    public void PuntuacionFinal() {
        var dictionary = RecipeManager.Instance.PlayerRecetas;
        foreach (var item in dictionary)
        {
            PuntuacionCount = item.Key.puntos * item.Value;
        }
        FinDelTurno();
    }

}
