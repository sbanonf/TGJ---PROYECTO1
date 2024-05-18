using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetearReceta : MonoBehaviour
{
    public ScriptableRecipe recipe;
    public TextMeshProUGUI descripcion;
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI puntos;
    public Image image;
    public GameObject padre;
    public GameObject padrePrefab;

    private void Start()
    {
        descripcion.text = recipe.Descripcion;
        nombre.text = recipe.nombre;
        image.sprite = recipe.sprite;
        puntos.text = recipe.puntos.ToString();
        foreach (var ingrediente in recipe.ingredientsNeeded) {
            GameObject aux = padrePrefab;
            aux.GetComponent<SetearIngrediente>().ingrediente = ingrediente.ingrendiente;
            aux.GetComponent<SetearIngrediente>().cantidad.text = ingrediente.quantity.ToString();
            Instantiate(aux, padre.transform);
        }
    }



}
