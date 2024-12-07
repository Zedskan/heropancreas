using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Referencias a las imágenes de las barras
    public Image healthBarFillPlayer1;
    public Image skillBarFillPlayer1;
    public Image healthBarFillPlayer2;
    public Image skillBarFillPlayer2;

    // Referencia al temporizador
    public TextMeshProUGUI timerText;

    // Configuración del temporizador
    public float matchDuration = 60f; // Duración del combate en segundos
    private float timeRemaining;

    // Variables de habilidad
    private float skillBarValuePlayer1 = 0f;
    private float skillBarValuePlayer2 = 0f;
    public float maxSkillValue = 100f; // Valor máximo de la barra de habilidad

    void Start()
    {
        // Inicializar el temporizador
        timeRemaining = matchDuration;

        // Inicializar las barras (100% llenas al inicio)
        UpdateHealth(1, 1f);
        UpdateSkillBar(1, 10f);
        UpdateHealth(2, 1f);
        UpdateSkillBar(2, -5f);
    }

    void Update()
    {
        UpdateTimer();
    }

    // Actualizar el temporizador
    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timeRemaining).ToString("00");
        }
        else
        {
            timerText.text = "00";
            EndMatch();
        }
    }

    // Método para actualizar las barras de vida
    public void UpdateHealth(int player, float healthPercentage)
    {
        healthPercentage = Mathf.Clamp01(healthPercentage); // Limitar entre 0 y 1
        if (player == 1)
            healthBarFillPlayer1.fillAmount = healthPercentage;
        else if (player == 2)
            healthBarFillPlayer2.fillAmount = healthPercentage;
    }

    // Método para incrementar o decrementar la barra de habilidad
    public void UpdateSkillBar(int player, float amount)
    {
        if (player == 1)
        {
            skillBarValuePlayer1 = Mathf.Clamp(skillBarValuePlayer1 + amount, 0, maxSkillValue);
            skillBarFillPlayer1.fillAmount = skillBarValuePlayer1 / maxSkillValue;
        }
        else if (player == 2)
        {
            skillBarValuePlayer2 = Mathf.Clamp(skillBarValuePlayer2 + amount, 0, maxSkillValue);
            skillBarFillPlayer2.fillAmount = skillBarValuePlayer2 / maxSkillValue;
        }
    }

    // Obtener el valor actual de la barra de habilidad
    public float GetSkillBarValue(int player)
    {
        return player == 1 ? skillBarValuePlayer1 : skillBarValuePlayer2;
    }

    // Método llamado al terminar el combate
    void EndMatch()
    {
        Debug.Log("¡El combate ha terminado!");
        // Aquí puedes agregar lógica para determinar al ganador y mostrar resultados.
    }
}
