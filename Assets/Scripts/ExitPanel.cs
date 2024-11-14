using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    public GameObject panelUI;  // Referencia al panel de UI que debe cerrarse

    // Este método se llama cuando el usuario presiona el botón de "Salir"
    public void ClosePanel()
    {
        panelUI.SetActive(false);  // Desactiva el panel
    }
}
