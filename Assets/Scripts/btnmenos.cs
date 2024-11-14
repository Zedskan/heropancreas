using TMPro;
using UnityEngine;

public class btnmenos : MonoBehaviour
{
    public TextMeshProUGUI quantityText;  // Referencia al TextMeshPro que muestra la cantidad

    private void Start()
    {
        // Asegurarse de que el valor inicial en el TextMeshPro es numérico y válido
        if (!int.TryParse(quantityText.text, out int initialQuantity))
        {
            initialQuantity = 1;  // Si el texto no es válido, se inicializa en 1
            quantityText.text = initialQuantity.ToString();
        }
    }

    public void Decrement()
    {
        // Leer el valor actual del TextMeshProUGUI como un entero
        int currentQuantity;
        if (int.TryParse(quantityText.text, out currentQuantity) && currentQuantity > 1)
        {
            currentQuantity--;  // Disminuir solo si el valor es mayor que 1
            quantityText.text = currentQuantity.ToString();  // Actualizar el texto con el nuevo valor
        }
    }
}
