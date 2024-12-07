using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Jugador a seguir
    public Vector3 offset; // Desplazamiento de la cámara

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }
}
