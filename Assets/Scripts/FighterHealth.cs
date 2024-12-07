using UnityEngine;

public class FighterHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        Debug.Log($"Fighter recibió {damage} daño. Vida actual: {currentHealth}");
    }

    public float GetCurrentHealthPercentage()
    {
        return currentHealth / maxHealth;
    }
}
