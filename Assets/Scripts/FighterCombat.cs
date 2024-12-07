using UnityEngine;

public class FighterCombat : MonoBehaviour
{
    public int playerID; // Identificador del jugador
    public int basicAttackDamage = 10; // Daño del ataque básico
    public int specialAttackDamage = 25; // Daño del ataque especial
    public float attackRange = 2f; // Rango del ataque básico
    public float comboTime = 1f; // Tiempo máximo entre ataques para un combo
    public float specialCost = 20f; // Costo de barra para el ataque especial
    public float skillGainPerHit = 5f; // Ganancia de barra por golpe exitoso

    public Transform attackPoint; // Punto de origen del ataque
    public LayerMask enemyLayer; // Capa de los enemigos
    public GameObject selectedPlayerPrefab; // Prefab del jugador seleccionado

    private int comboCount = 0; // Contador para combos básicos
    private int specialComboCount = 0; // Contador para combos especiales
    private float lastAttackTime = 0f; // Momento del último ataque

    private UIManager uiManager;
    private Animator animator;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        // Instanciar el modelo del jugador seleccionado
        if (selectedPlayerPrefab != null)
        {
            GameObject playerModel = Instantiate(selectedPlayerPrefab, transform.position, transform.rotation, transform);
            animator = playerModel.GetComponent<Animator>();

            if (animator == null)
            {
                Debug.LogError("El prefab del jugador no tiene un Animator.");
            }
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Autocombo básico
        {
            BasicCombo();
        }
        if (Input.GetButtonDown("Fire2")) // Autocombo fuerte (consume barra)
        {
            SpecialCombo();
        }
    }

    void BasicCombo()
    {
        if (Time.time - lastAttackTime <= comboTime)
        {
            comboCount++;
        }
        else
        {
            comboCount = 1; // Reinicia combo si pasó mucho tiempo
        }

        lastAttackTime = Time.time;

        // Ejecutar animación y lógica del combo
        string animationTrigger = "BasicCombo" + comboCount; // Por ejemplo: BasicCombo1, BasicCombo2, etc.
        if (animator != null)
        {
            animator.SetTrigger(animationTrigger);
        }

        // Detectar enemigos y aplicar daño
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            FighterHealth enemyHealth = enemy.GetComponent<FighterHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(basicAttackDamage);
                uiManager.UpdateSkillBar(playerID, skillGainPerHit);
            }
        }
    }

    void SpecialCombo()
    {
        if (!CanUseSpecial()) return; // Verificar si hay suficiente barra

        if (Time.time - lastAttackTime <= comboTime)
        {
            specialComboCount++;
        }
        else
        {
            specialComboCount = 1; // Reinicia combo especial si pasó mucho tiempo
        }

        lastAttackTime = Time.time;

        // Ejecutar animación y lógica del combo especial
        string animationTrigger = "SpecialCombo" + specialComboCount; // Por ejemplo: SpecialCombo1, SpecialCombo2, etc.
        if (animator != null)
        {
            animator.SetTrigger(animationTrigger);
        }

        // Detectar enemigos y aplicar daño mayor
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange * 1.5f, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            FighterHealth enemyHealth = enemy.GetComponent<FighterHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(specialAttackDamage);
            }
        }

        // Reducir barra de habilidad
        uiManager.UpdateSkillBar(playerID, -specialCost);
    }

    bool CanUseSpecial()
    {
        return uiManager.GetSkillBarValue(playerID) >= specialCost;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
