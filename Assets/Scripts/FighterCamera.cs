using UnityEngine;

public class FighterCamera : MonoBehaviour
{
    public Transform player1; // Transform del primer jugador
    public Transform player2; // Transform del segundo jugador

    public float minDistance = 5f;  // Distancia mínima de la cámara
    public float maxDistance = 15f; // Distancia máxima de la cámara
    public float followSpeed = 5f;  // Velocidad con la que la cámara sigue a los personajes
    public float zoomSpeed = 5f;    // Velocidad de zoom de la cámara
    public float heightOffset = 5f; // Altura de la cámara desde el plano

    private Vector3 targetPosition; // Posición objetivo de la cámara
    private float targetDistance;   // Distancia objetivo de la cámara

    void LateUpdate()
    {
        UpdateCameraPosition();
        UpdateCameraZoom();
        ClampPlayersWithinBounds();
    }

    // Actualiza la posición de la cámara
    void UpdateCameraPosition()
    {
        // Calcula el punto medio entre los dos personajes
        Vector3 midpoint = (player1.position + player2.position) / 2f;
        midpoint.y = heightOffset; // Mantén la cámara a una altura fija

        // Actualiza la posición objetivo suavemente
        targetPosition = midpoint;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    // Actualiza el zoom de la cámara según la distancia entre los personajes
    void UpdateCameraZoom()
    {
        // Calcula la distancia entre los dos personajes
        float distance = Vector3.Distance(player1.position, player2.position);

        // Ajusta la distancia objetivo de la cámara según los límites
        targetDistance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Mueve la cámara hacia atrás o adelante suavemente
        Vector3 cameraDirection = transform.forward * -1; // Dirección opuesta al frente de la cámara
        transform.position = Vector3.Lerp(transform.position, targetPosition + cameraDirection * targetDistance, zoomSpeed * Time.deltaTime);
    }
    // Restringe a los jugadores para que permanezcan dentro de la distancia máxima
    void ClampPlayersWithinBounds()
    {
        float distance = Vector3.Distance(player1.position, player2.position);

        // Si la distancia excede el máximo permitido, ajusta las posiciones
        if (distance > maxDistance)
        {
            Vector3 direction = (player1.position - player2.position).normalized;
            Vector3 midpoint = (player1.position + player2.position) / 2f;

            // Reposiciona a los jugadores dentro del límite
            player1.position = midpoint + direction * (maxDistance / 2f);
            player2.position = midpoint - direction * (maxDistance / 2f);
        }
    }
}
