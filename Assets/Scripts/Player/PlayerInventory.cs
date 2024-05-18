using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	
	private IngredientType carryIngredient;

	[SerializeField] private bool canDrop = false;


	public void TakeIngredient(ScriptableIngredient ingredient) {
		carryIngredient = ingredient.ingredientType;
		transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = ingredient.sprite;
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.F) && canDrop && carryIngredient != IngredientType.None) {
			FindObjectOfType<ShoppingCar>().AddIngredient(carryIngredient);
			transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
			carryIngredient = IngredientType.None;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Ingredient")) {
			ScriptableIngredient ingredient = FindObjectOfType<ResourceSystem>().GetIngredient(
				other.GetComponent<Ingredient>().GetIngredientType());
			TakeIngredient(ingredient);
		}

		else if(other.CompareTag("ShoppingCar")) {
			canDrop = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("ShoppingCar")) {
			canDrop = false;
		}
	}

}