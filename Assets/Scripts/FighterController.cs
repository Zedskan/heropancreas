using UnityEngine;

public class FighterController : MonoBehaviour
{
    public float moveSpeed = 5f;         // Velocidad de movimiento
    public Transform opponent;          // Referencia al oponente

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        LookAtOpponent();
    }

    // Movimiento limitado al eje X
    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento izquierda/derecha
        Vector3 movement = new Vector3(horizontal, 0, 0); // Solo movimiento en el eje X

        if (movement.magnitude > 0)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        }
    }

    // Mirar siempre hacia el oponente
    void LookAtOpponent()
    {
        if (opponent != null)
        {
            Vector3 direction = (opponent.position - transform.position).normalized;
            direction.y = 0; // Evita inclinarse hacia arriba/abajo

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

        }
    }
}
