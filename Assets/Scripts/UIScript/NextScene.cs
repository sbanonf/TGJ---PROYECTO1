using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void Next(string SceneName)
    {
      SceneManager.LoadScene(SceneName);
    }

    public void Click() {
        audioManager.Instance.Play("click");
    }

    public void FinTurno() {
        PuntuacionManager.Instance.FinDelTurno();
    }

    public void Reset()
    {
        PuntuacionManager.Instance.Reset();
        IngredientSystem.Instance.ResetIngredients();
    }
}
