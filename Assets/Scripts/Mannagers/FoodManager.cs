using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    public TextMeshProUGUI[] textos;
    public Image[] images;
    Dictionary<IngredientType, int> allIngredients = null;

    private void Update() {

        if (allIngredients == null){
            GetIngredients();
        }
        
        List<IngredientType> ingredientKeys = allIngredients.Keys.ToList();
        List<int> ingredientValue = allIngredients.Values.ToList();

        for (int i = 0; i < allIngredients.Count; i++)
        {
        //     ScriptableIngredient var = ResourceSystem.Instance.GetIngredient(ingredientKeys[i]);
        //     images[i].sprite = var.sprite;
        //     textos[i].text = ingredientValue[i].ToString();
            Debug.Log("Valor:"+ingredientValue[i].ToString());
            Debug.Log("Ingrediente: "+ingredientKeys[i].ToString());
        }
    }

    private void GetIngredients(){
        allIngredients = IngredientSystem.Instance.GetAllIngredients();
        Debug.Log(allIngredients.ToString());
    }
}
