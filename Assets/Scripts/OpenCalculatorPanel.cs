using UnityEngine;

public class OpenCalculatorPanel : MonoBehaviour
{
    public GameObject calculatorPanel;  // Referencia al panel de la calculadora

    // Este método se llama cuando el usuario presiona el botón de "Calculadora"
    public void ShowCalculator()
    {
        // Activa el panel de la calculadora
        calculatorPanel.SetActive(true);
    }
}
