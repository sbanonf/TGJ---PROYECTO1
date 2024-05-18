using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<ScriptableRecipe> recetas;
    public Dictionary<IngredientType,int> Playeringredients;
    public Dictionary<ScriptableRecipe,int> PlayerRecetas;
    public static RecipeManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Playeringredients = IngredientSystem.Instance.GetAllIngredients();
        PlayerRecetas = new Dictionary<ScriptableRecipe,int>();
    }
    public bool PuedePreparar(ScriptableRecipe receta) {
        
        foreach(var ingrediente in receta.ingredientsNeeded)
        {
            if(!Playeringredients.ContainsKey(ingrediente.ingrendiente.ingredientType) 
                || Playeringredients[ingrediente.ingrendiente.ingredientType] < ingrediente.quantity)
            {
                return false;
            }

        }
        return true;
    }

    public void PrepararReceta(ScriptableRecipe receta) {
        if (PuedePreparar(receta)) {
            foreach (var ingrediente in receta.ingredientsNeeded) {
                Playeringredients[ingrediente.ingrendiente.ingredientType] -= ingrediente.quantity;
            }
            if (PlayerRecetas.ContainsKey(receta))
            {
                PlayerRecetas[receta] += 1;
            }
            else { 
                PlayerRecetas.Add(receta, 1); 
            }
            Debug.Log("Se preparo la receta" + receta.name);
        }
    
    }
}
