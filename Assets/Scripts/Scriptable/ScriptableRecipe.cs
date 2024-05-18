using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Receta",menuName = "Receta/NuevaReceta")]
public class ScriptableRecipe : ScriptableObject
{
    public string nombre;
    public List<IngredientQuantity> ingredientsNeeded;
    public Sprite sprite;
}

[System.Serializable]
public class IngredientQuantity {
    public ScriptableIngredient ingrendiente;
    public int quantity;
}
