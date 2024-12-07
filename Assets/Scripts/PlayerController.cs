using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float rotationSpeed = 720f; // Velocidad de rotación
    public Animator animator; // Referencia al Animator
    public int health = 100; // Salud del personaje
    private bool isPerformingSpecial = false; // Estado para evitar otros movimientos durante el especial

    void Update()
    {
        if (isPerformingSpecial) return; // No permitir otros movimientos durante el especial

        HandleMovement();
        HandleAttacks();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Rotar hacia la dirección del movimiento
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Mover al personaje
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

            // Activar animación de correr
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    void HandleAttacks()
    {
        if (Input.GetKeyDown(KeyCode.J)) // Puñetazo
        {
            animator.SetTrigger("Punch");
        }
        if (Input.GetKeyDown(KeyCode.K)) // Patada
        {
            animator.SetTrigger("Kick");
        }
        if (Input.GetKeyDown(KeyCode.L)) // Movimiento especial
        {
            StartCoroutine(PerformSpecialMove());
        }
    }

    private IEnumerator PerformSpecialMove()
    {
        isPerformingSpecial = true;
        animator.SetTrigger("SpecialMove");

        // Esperar la duración de la animación especial (ajustar el tiempo según la animación)
        yield return new WaitForSeconds(3f);

        isPerformingSpecial = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        // Deshabilitar control del personaje
        this.enabled = false;
    }
}
