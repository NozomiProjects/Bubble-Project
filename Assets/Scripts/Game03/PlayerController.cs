using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta la colisi�n f�sica con los tubos
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Aqu� puedes realizar la acci�n de arrastre o detener al jugador
            // Por ejemplo, si el jugador choca con un tubo, podemos detener su movimiento
            rb.linearVelocity = Vector2.zero; // Detener al jugador al chocar

            // Aqu� puedes agregar un comportamiento como arrastrar al jugador con el tubo si lo deseas
            // Por ejemplo, puedes cambiar la velocidad del jugador o aplicar una fuerza hacia atr�s
        }
    }

}
