using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuItem : MonoBehaviour
{
    
    [SerializeField] private Animator UiAnimator;

    public void ActivarUIPanel(bool activacion)
    {
        if (activacion)
        {
            UiAnimator.SetTrigger("Return");
        }
        else
        {
            UiAnimator.SetTrigger("Go");
        }
    }


}
