using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

	private IngredientType ingredientType;

	void Start() {
		SelectIngredient();
	}

	private void SelectIngredient() {
		ScriptableIngredient ingredient = ResourceSystem.Instance.GetRandomIngredient();

		GetComponentInChildren<SpriteRenderer>().sprite = ingredient.sprite;
		ingredientType = ingredient.ingredientType;
	}

	public IngredientType GetIngredientType() {
		return ingredientType;
	}
}
