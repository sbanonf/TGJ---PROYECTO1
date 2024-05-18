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
    Dictionary<IngredientType, int> allIngredients;

    private void Start()
    {

    }
    private void Update()
    {
        allIngredients= IngredientSystem.Instance.GetAllIngredients();
        List<IngredientType> ingredientKeys = allIngredients.Keys.ToList();
        List<int> ingredientValue = allIngredients.Values.ToList();
       for(int i = 0; i < allIngredients.Count; i++)
        {
            ScriptableIngredient var = ResourceSystem.Instance.GetIngredient(ingredientKeys[i]);
            Debug.Log(var);
            images[i].sprite = var.sprite;
            textos[i].text= ingredientValue[i].ToString();
        }
    }   
}
