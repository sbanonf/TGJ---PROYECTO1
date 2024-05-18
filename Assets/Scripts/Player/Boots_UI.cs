using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boots_UI : MonoBehaviour
{
    public float vida;
    public float vidaMax;

    public Image playerVida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void RecivirDanio(float cantidad)
    //{
    //    vida -= cantidad;
    //    ActualizarUI(vida, vidaMax);
        
    //}

    //public void RegenerarMana()
    //{
    //    if (vidaMax > 0f && vida < vidaMax)
    //    {
    //        ManaActual += regeneracionPorSegundo;
    //        ActualizarUI();
    //    }
    //}

    //public void ActualizarUI(float vida, float vidaMax)
    //{
    //    playerVida.fillAmount = Mathf.Lerp(playerVida.fillAmount, vida / vidaMax, 10f * Time.deltaTime);
    //}
}
