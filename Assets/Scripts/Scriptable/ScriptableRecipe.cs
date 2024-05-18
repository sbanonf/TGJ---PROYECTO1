using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Receta",menuName = "Receta/NuevaReceta")]
public class ScriptableRecipe : ScriptableObject
{
    public string nombre;
    [TextArea(5,5)]
    public string Descripcion;
    public List<IngredientQuantity> ingredientsNeeded;
    public Sprite sprite;
    public int puntos;
}

[System.Serializable]
public class IngredientQuantity {
    public ScriptableIngredient ingrendiente;
    public int quantity;
}
