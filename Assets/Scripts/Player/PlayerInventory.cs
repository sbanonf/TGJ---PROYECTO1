using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	private IngredientType[] carryIngredients = new IngredientType[3];

	[SerializeField] private bool canDrop = false;
	[SerializeField] private bool canPick = false;
	[SerializeField] private bool isCarrying = false;
	[SerializeField] private int actualID = 0;

	private ScriptableIngredient pickableIngredient;


	public void TakeIngredient(ScriptableIngredient ingredient) {
		if (actualID < 3) {
			carryIngredients[actualID] = ingredient.ingredientType;
			transform.GetChild(actualID).GetComponent<SpriteRenderer>().sprite = ingredient.sprite;
			actualID++;
			isCarrying = true;
		}
	}

	private void DropIngredients(){
		for (int i = 0; i < carryIngredients.Length; i++) {
			if(carryIngredients[i] == IngredientType.None) 
				continue;
			FindObjectOfType<IngredientSystem>().AddIngredient(carryIngredients[i]);
			carryIngredients[i] = IngredientType.None;
			transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = null;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.F)) {
			if(canDrop){
				DropIngredients();
				audioManager.instance.Play("soltar");
				actualID = 0;
				isCarrying = false;
			}

			if (canPick) {
				audioManager.instance.Play("coger");
				TakeIngredient(pickableIngredient);
			}
			
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Ingredient")) {
			canPick = true;
			pickableIngredient = FindObjectOfType<ResourceSystem>().GetIngredient(
				other.GetComponentInParent<Ingredient>().GetIngredientType()
			);
		}

		else if(other.CompareTag("ShoppingCar")) {
			canDrop = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("ShoppingCar")) {
			canDrop = false;
		}
		if (other.CompareTag("Ingredient")) {
			canPick = false;
		}
	}

	public bool IsCarrying() {
		return isCarrying;
	}

}