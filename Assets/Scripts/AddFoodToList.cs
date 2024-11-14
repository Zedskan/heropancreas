using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddFoodToList : MonoBehaviour
{
    public TextMeshProUGUI quantityText;    // El texto donde está la cantidad ingresada
    public TextMeshProUGUI titleText;       // El texto que contiene el nombre del alimento
    public GameObject panelUI;              // Referencia al panel de UI que debe cerrarse
    public ShowFoodList showFoodListScript; // Referencia al script de ShowFoodList

    // Lista donde se guardarán los alimentos con su cantidad y calorías
    private List<FoodItem> foodList = new List<FoodItem>();

    // Este método se llama cuando el usuario presiona el botón de agregar
    public void AddFood()
    {
        string foodName = titleText.text;  // Obtiene el nombre del alimento
        int quantity = int.Parse(quantityText.text);  // Convierte la cantidad ingresada en un número entero

        // Verifica las calorías según el nombre del alimento
        int calories = GetCaloriesForFood(foodName);
        int totalCalories = calories * quantity;  // Calcula las calorías totales

        // Agregar a la lista
        FoodItem newItem = new FoodItem(foodName, quantity, totalCalories);
        foodList.Add(newItem);

        // Llama al método en ShowFoodList para actualizar la visualización
        showFoodListScript.UpdateFoodListDisplay(foodList);  // Pasamos la lista actualizada

        // (Opcional) Muestra en consola el alimento agregado
        Debug.Log($"Agregado: {newItem.foodName} - Cantidad: {newItem.quantity} - Calorías: {newItem.totalCalories}");

        // Cierra el panel de UI (desactiva el GameObject)
        ClosePanel();
    }

    // Método para cerrar el panel de UI
    private void ClosePanel()
    {
        panelUI.SetActive(false);  // Desactiva el panel
    }

    // Método para obtener las calorías de un alimento según su nombre
    private int GetCaloriesForFood(string foodName)
    {
        switch (foodName)
        {
            case "Manzana Roja":
                return 52;  // Calorías por 100g
            case "Banana Madura":
                return 89;
            case "Cereza":
                return 50;
            case "Queso":
                return 402;
            case "Fresa":
                return 32;
            case "Hamburguesa":
                return 250;  // Promedio por unidad
            case "Hotdog":
                return 290;
            case "Sandía":
                return 30;
            case "Tomate":
                return 18;
            case "Zanahoria":
                return 41;
            case "Naranja":
                return 47;
            default:
                return 0; // Si no coincide con ningún caso, retorna 0
        }
    }

    // Clase que representa un alimento y su información
    [System.Serializable]
    public class FoodItem
    {
        public string foodName;
        public int quantity;
        public int totalCalories;

        // Constructor
        public FoodItem(string name, int qty, int calories)
        {
            foodName = name;
            quantity = qty;
            totalCalories = calories;
        }
    }
}
