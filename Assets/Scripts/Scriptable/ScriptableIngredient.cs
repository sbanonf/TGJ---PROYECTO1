using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient")]
public class ScriptableIngredient : ScriptableObject {
	
	public Sprite sprite;

	public IngredientType ingredientType;
}

[Serializable]
public enum IngredientType {
	None,
	PapaAlien,
	Banana,
	Cherry,
	Orange,
	Pear
}