using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetearTiempo : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    private void Start()
    {
        tmpro=GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        tmpro.text = Math.Round(TimeManager.instance.tiempoRuntime).ToString();
    }
}
