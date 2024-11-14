using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ScriptPanel : MonoBehaviour
{
    public GameObject uiPanel;       // El panel de UI que deseas mostrar
    public TextMeshProUGUI titleText;           // Texto para el título
    public TextMeshProUGUI subtitleText;        // Texto para el subtítulo
    public TextMeshProUGUI descriptionText;     // Texto para la descripción
    private ObserverBehaviour observerBehaviour;  // Para manejar el comportamiento de detección del Image Target

    void Start()
    {
        // Obtén el componente ObserverBehaviour del Image Target al que está adjunto este script
        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour != null)
        {
            // Suscribirse a los eventos de estado de observación
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        // Asegúrate de que el panel de UI esté desactivado al inicio
        uiPanel.SetActive(false);
    }

    // Evento que se activa cuando el estado del target cambia (detectado/no detectado)
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            // Si el Image Target se ha detectado, muestra el panel de UI con información específica
            ShowFruitInfo();
        }
        else
        {
            // Si el Image Target no se está detectando, oculta el panel de UI
            HideFruitInfo();
        }
    }

    private void ShowFruitInfo()
    {
        // Activa el panel de UI
        uiPanel.SetActive(true);

        // Identifica el objeto y actualiza la UI
        string fruitName = gameObject.name;  // Usa el nombre del objeto para identificarlo
        switch (fruitName)
        {
            case "Apple":
                titleText.text = "Manzana Roja";
                subtitleText.text = "Fruta baja en calorías y rica en fibra";
                descriptionText.text = "Calorías: 52 kcal por 100g\n" +
                                       "Carbohidratos: 14g\n" +
                                       "Fibra: 2.4g\n" +
                                       "Azúcares: 10g (natural)\n" +
                                       "Índice Glucémico: Bajo (IG 39)\n\n" +
                                       "Beneficios: Ayuda a reducir el pico de glucosa.\n" +
                                       "Riesgos: Consumir con moderación por azúcares.";
                break;

            case "Banana":
                titleText.text = "Banana Madura";
                subtitleText.text = "Energizante y rica en potasio";
                descriptionText.text = "Calorías: 89 kcal por 100g\n" +
                                       "Carbohidratos: 23g\n" +
                                       "Fibra: 2.6g\n" +
                                       "Azúcares: 12g (natural)\n" +
                                       "Índice Glucémico: Medio (IG 51)\n\n" +
                                       "Beneficios: Proporciona energía rápida y es rica en potasio.\n" +
                                       "Riesgos: Incrementa los niveles de glucosa más rápido.";
                break;

            case "Cherry":
                titleText.text = "Cereza";
                subtitleText.text = "Fruta pequeña y rica en antioxidantes";
                descriptionText.text = "Calorías: 50 kcal por 100g\n" +
                                       "Carbohidratos: 12g\n" +
                                       "Fibra: 1.6g\n" +
                                       "Azúcares: 8g (natural)\n" +
                                       "Índice Glucémico: Bajo (IG 22)\n\n" +
                                       "Beneficios: Reduce inflamación y aporta antioxidantes.\n" +
                                       "Riesgos: Consumir con moderación por su contenido de fructosa.";
                break;

            case "Cheese":
                titleText.text = "Queso";
                subtitleText.text = "Rico en proteínas y calcio, ideal en moderación";
                descriptionText.text = "Calorías: 402 kcal por 100g\n" +
                                       "Carbohidratos: 1.3g\n" +
                                       "Proteínas: 25g\n" +
                                       "Grasas: 33g\n" +
                                       "Calcio: Alto\n\n" +
                                       "Beneficios: Fortalece huesos y aporta proteínas.\n" +
                                       "Riesgos: Moderar por grasas y sodio.";
                break;

            case "Strawberry":
                titleText.text = "Fresa";
                subtitleText.text = "Fruta dulce y baja en calorías, rica en vitamina C";
                descriptionText.text = "Calorías: 32 kcal por 100g\n" +
                                       "Carbohidratos: 7.7g\n" +
                                       "Fibra: 2g\n" +
                                       "Azúcares: 4.9g (natural)\n\n" +
                                       "Beneficios: Refuerza el sistema inmune.\n" +
                                       "Riesgos: Consumir moderadamente por su contenido de fructosa.";
                break;

            case "Hamburger":
                titleText.text = "Hamburguesa";
                subtitleText.text = "Alimento energético, alto en proteínas y grasas";
                descriptionText.text = "Calorías: 250-300 kcal por unidad\n" +
                                       "Carbohidratos: 30g\n" +
                                       "Proteínas: 17g\n" +
                                       "Grasas: 13g\n\n" +
                                       "Beneficios: Aporta proteínas para el músculo.\n" +
                                       "Riesgos: Alto en grasas y sodio; moderar su consumo.";
                break;

            case "Hotdog":
                titleText.text = "Hotdog";
                subtitleText.text = "Aperitivo rápido, alto en grasas y sodio";
                descriptionText.text = "Calorías: 290 kcal por unidad\n" +
                                       "Carbohidratos: 23g\n" +
                                       "Proteínas: 11g\n" +
                                       "Grasas: 19g\n\n" +
                                       "Beneficios: Aporta proteínas y energía.\n" +
                                       "Riesgos: Alto en grasas saturadas y sodio.";
                break;

            case "Watermelon":
                titleText.text = "Sandía";
                subtitleText.text = "Fruta refrescante, rica en agua y antioxidantes";
                descriptionText.text = "Calorías: 30 kcal por 100g\n" +
                                       "Carbohidratos: 8g\n" +
                                       "Fibra: 0.4g\n" +
                                       "Azúcares: 6g (natural)\n" +
                                       "Índice Glucémico: Medio (IG 72)\n\n" +
                                       "Beneficios: Hidrata y contiene licopeno antioxidante.\n" +
                                       "Riesgos: Moderar en dietas de bajo índice glucémico.";
                break;

            case "Tomato":
                titleText.text = "Tomate";
                subtitleText.text = "Bajo en calorías, alto en vitamina C y antioxidantes";
                descriptionText.text = "Calorías: 18 kcal por 100g\n" +
                                       "Carbohidratos: 3.9g\n" +
                                       "Fibra: 1.2g\n" +
                                       "Azúcares: 2.6g (natural)\n" +
                                       "Índice Glucémico: Bajo (IG 15)\n\n" +
                                       "Beneficios: Apoya la salud cardíaca y reduce la inflamación.\n" +
                                       "Riesgos: Alergias leves en personas sensibles.";
                break;

            case "Carrot":
                titleText.text = "Zanahoria";
                subtitleText.text = "Buena fuente de betacaroteno y fibra";
                descriptionText.text = "Calorías: 41 kcal por 100g\n" +
                                       "Carbohidratos: 10g\n" +
                                       "Fibra: 2.8g\n" +
                                       "Azúcares: 4.7g (natural)\n" +
                                       "Índice Glucémico: Medio (IG 47)\n\n" +
                                       "Beneficios: Mejora la visión y protege la piel.\n" +
                                       "Riesgos: Moderar si se necesita un IG bajo.";
                break;

            case "Orange":
                titleText.text = "Naranja";
                subtitleText.text = "Cítrico rico en vitamina C y antioxidantes";
                descriptionText.text = "Calorías: 47 kcal por 100g\n" +
                                       "Carbohidratos: 12g\n" +
                                       "Fibra: 2.4g\n" +
                                       "Azúcares: 9g (natural)\n" +
                                       "Índice Glucémico: Bajo (IG 43)\n\n" +
                                       "Beneficios: Refuerza el sistema inmune y es antioxidante.\n" +
                                       "Riesgos: Puede ser ácido para algunas personas.";
                break;





            // Agrega más frutas según sea necesario...

            default:
                titleText.text = "Fruta Desconocida";
                subtitleText.text = "No se dispone de información";
                descriptionText.text = "Escanee otro alimento para obtener información nutricional.";
                break;
        }
    }

    private void HideFruitInfo()
    {
        // Oculta el panel de UI
        uiPanel.SetActive(false);
    }

    void OnDestroy()
    {
        // Desuscribirse del evento para evitar errores al destruir el objeto
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
