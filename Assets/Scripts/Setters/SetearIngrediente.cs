using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetearIngrediente : MonoBehaviour
{
    public ScriptableIngredient ingrediente;
    public TextMeshProUGUI cantidad;
    private void Start()
    {
         GetComponent<Image>().sprite = ingrediente.sprite;

    }
}
