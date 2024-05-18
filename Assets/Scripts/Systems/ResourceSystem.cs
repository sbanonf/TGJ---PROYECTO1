using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ResourceSystem : StaticInstance<ResourceSystem> {

	public List<ScriptableIngredient> Ingredients { get; private set; }
	private Dictionary<IngredientType, ScriptableIngredient> IngredientsDict;

	protected override void Awake() {
		base.Awake();
		AssembleResources();
	}

	private void AssembleResources() {
		Ingredients = Resources.LoadAll<ScriptableIngredient>("Ingredients").ToList();
		IngredientsDict = Ingredients.ToDictionary(r => r.ingredientType, r => r);
	}

	public ScriptableIngredient GetIngredient(IngredientType t) => IngredientsDict[t];
	public ScriptableIngredient GetRandomIngredient() => Ingredients[Random.Range(0, Ingredients.Count)];
}   