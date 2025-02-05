using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Acceder al GameManager y a�adir puntos
            GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddPoints(1); // A�adir 1 punto
            }
            //Debug.Log("Punto a�adido!");
        }
    }
}
