using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{

    Dictionary<IngredientType, int> allIngredients = null;
    public GameObject prefab;
    public GameObject papa;

    public static FoodManager instance;
    public Image[] images;
    private void Update() {
        

    }
    private void Start()
    {
        instance = this;
        if (allIngredients == null)
        {
            GetIngredients();
        }

        List<IngredientType> ingredientKeys = allIngredients.Keys.ToList();
        List<int> ingredientValue = allIngredients.Values.ToList();

        for (int i = 0; i < ingredientKeys.Count; i++)
        {
            Debug.Log("Entre");
            Debug.Log(ingredientKeys.Count);
            Debug.Log(allIngredients.Count);
            ScriptableIngredient var = ResourceSystem.Instance.GetIngredient(ingredientKeys[i]);
            var aux = prefab;
            aux.GetComponent<Image>().sprite = var.sprite;
            aux.GetComponentInChildren<TextMeshProUGUI>().text = ingredientValue[i].ToString();
            Instantiate(prefab, papa.transform);
        }
        images = papa.GetComponentsInChildren<Image>();
    }

    public void Updatear() {
        List<IngredientType> ingredientKeys = allIngredients.Keys.ToList();
        List<int> ingredientValue = allIngredients.Values.ToList();

        for (int i = 0; i < ingredientKeys.Count; i++) {
            ScriptableIngredient var = ResourceSystem.Instance.GetIngredient(ingredientKeys[i]);
            images[i].GetComponent<Image>().sprite = var.sprite;
            images[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = ingredientValue[i].ToString();
        }

    }

    


    private void GetIngredients(){
        allIngredients = IngredientSystem.Instance.GetAllIngredients();
    }
}
