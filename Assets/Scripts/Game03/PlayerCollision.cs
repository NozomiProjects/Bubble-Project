using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isInvulnerable = false; // Estado de invulnerabilidad
    public float invulnerabilityDuration = 1f; // Duraci�n de la inmunidad

    // Define un valor de X para determinar si el jugador est� atrapado
    public float gameOverXPosition = -10f; // Ajusta este valor seg�n la posici�n de tus tubos

    [SerializeField] private AudioSource sfxHit;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Comprobar si el jugador est� atrapado
        if (transform.position.x < gameOverXPosition)
        {
            TriggerGameOver(); // Activar Game Over si el jugador est� atrapado
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && !isInvulnerable)
        {
            sfxHit.Play();
            // Llamar al sistema de vidas para restar una vida
            GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.LoseLife(); // Restar una vida y actualizar la UI
                
            }
            else
            {
                Debug.LogWarning("GameManager no encontrado en la escena.");
            }

            // Iniciar retroalimentaci�n visual
            StartCoroutine(HandleDamageFeedback());
        }
    }

    private IEnumerator HandleDamageFeedback()
    {
        isInvulnerable = true;

        // Cambiar color a rojo
        spriteRenderer.color = Color.red;

        // Esperar el tiempo de invulnerabilidad
        yield return new WaitForSeconds(invulnerabilityDuration);

        // Restaurar color original
        spriteRenderer.color = Color.white;

        isInvulnerable = false;
    }

    private void TriggerGameOver()
    {
        // Llamar al GameManager para que termine el juego
        LifeManager.Instance.LoseAllLives(); // Perder todas las vidas

        // Cambiar a la pantalla de Game Over inmediatamente
        GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.LoadGameOverScene(); // Cargar la escena de Game Over
        }
    }
}
