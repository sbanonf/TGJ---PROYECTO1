using System.Collections.Generic;
using UnityEngine;

public class IngredientSystem : StaticInstance<IngredientSystem>{
	private static Dictionary<IngredientType, int> Ingredients = new();

	protected override void Awake() {
		base.Awake();
		// Ingredients = new Dictionary<IngredientType, int>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			foreach (KeyValuePair<IngredientType, int> ingredient in Ingredients) {
				Debug.Log(ingredient.Key + " " + ingredient.Value);
			}
		}
	}

	public void AddIngredient(IngredientType ingredientType) {
		if (Ingredients.ContainsKey(ingredientType)) {
			Ingredients[ingredientType]++;
		} 
		else {
			Ingredients.Add(ingredientType, 1);
		}
	}
    public Dictionary<IngredientType, int> GetAllIngredients()
    {
		return Ingredients;
    }

	public void ResetIngredients() {
		Ingredients.Clear();
	}
}