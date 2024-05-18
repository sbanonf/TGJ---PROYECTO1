using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntuacionManager : Singleton<PuntuacionManager>
{
    public int PuntuacionCount;
    public int incremento;
    public int MetaPuntuacion;
    public static PuntuacionManager instance;
    protected override void Awake()
    {
        base.Awake();
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
    public void FinDelTurno() {
        if (PuntuacionCount >= MetaPuntuacion)
        {
            MetaPuntuacion += incremento;
        }
        else {
            TimeManager.instance.isGameFinished = true;
        }
        TimeManager.instance.FinTurno();
    }

    public void PuntuacionFinal() {
        var dictionary = RecipeManager.instance.PlayerRecetas;
        foreach (var item in dictionary)
        {
            PuntuacionCount = item.Key.puntos * item.Value;
        }
        FinDelTurno();
    }

}
