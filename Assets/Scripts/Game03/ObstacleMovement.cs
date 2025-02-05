using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -15) // Fuera de la cámara
        {
            Destroy(gameObject); // Destruir para optimizar
        }
    }
}
