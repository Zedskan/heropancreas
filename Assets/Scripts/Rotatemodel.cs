using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatemodel : MonoBehaviour
{
    public float rotationSpeed = 150.0f;  // Velocidad de rotación ajustable

    private void Update()
    {
        // Control para dispositivos táctiles
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Gira el modelo en el eje X según el movimiento vertical del dedo
                float rotationAmount = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;
                transform.Rotate(rotationAmount, 0, 0, Space.World);  // Gira en el eje X (como un planeta)
            }
        }
        // Control para el ratón en computadoras
        else if (Input.GetMouseButton(0))
        {
            float rotationAmount = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationAmount, 0, 0, Space.World);  // Gira en el eje X (como un planeta)
        }
    }
}
