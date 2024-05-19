using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecipeManager : StaticInstance<RecipeManager>
{
    public List<ScriptableRecipe> recetas;
    public Dictionary<IngredientType,int> Playeringredients;
    public Dictionary<ScriptableRecipe,int> PlayerRecetas;
    
    protected override void Awake()
    {
        base.Awake();
       
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
            FoodManager.instance.Updatear();
            PuntuacionManager.Instance.PuntuacionCount += receta.puntos;
            Debug.Log("Se preparo la receta" + receta.name);
        }
    
    }
}
