using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFoodList : MonoBehaviour
{
    public TextMeshProUGUI foodListText;    // El texto donde se mostrará la lista de alimentos
    public TextMeshProUGUI titleText;       // El texto que contiene el título ("Lista de Alimentos")
    public TextMeshProUGUI totalCaloriesText; // El texto que mostrará las calorías totales

    // Este método se llama para actualizar la visualización de la lista de alimentos
    public void UpdateFoodListDisplay(List<AddFoodToList.FoodItem> foodList)
    {
        foodListText.text = ""; // Limpiar el texto actual

        // Mostrar los alimentos de la lista
        foreach (var food in foodList)
        {
            // Agregar un ítem a la lista, con el formato que desees (nombre, cantidad, calorías)
            foodListText.text += $"{food.foodName} - Cantidad: {food.quantity} - Calorías: {food.totalCalories}\n";
        }

        // Actualizar las calorías totales
        UpdateTotalCalories(foodList);
    }

    // Calcula y actualiza las calorías totales
    private void UpdateTotalCalories(List<AddFoodToList.FoodItem> foodList)
    {
        int totalCalories = 0;

        // Sumar las calorías de todos los alimentos (sumando las calorías totales por producto)
        foreach (var food in foodList)
        {
            totalCalories += food.totalCalories;
        }

        // Mostrar las calorías totales
        totalCaloriesText.text = totalCalories.ToString();
    }
}
