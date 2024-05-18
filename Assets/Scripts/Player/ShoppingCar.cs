using System.Collections.Generic;
using UnityEngine;

public class ShoppingCar : MonoBehaviour {
	private Dictionary<IngredientType, int> Ingredients;

	private void Awake() {
		Ingredients = new Dictionary<IngredientType, int>();
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
		} else {
			Ingredients.Add(ingredientType, 1);
		}
	}
}