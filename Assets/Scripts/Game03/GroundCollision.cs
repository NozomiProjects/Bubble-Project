using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Restar vida al jugador
            LifeManager.Instance.LoseLife(); // Descontar una vida
            Debug.Log("Jugador toc� el suelo y perdi� una vida.");
        }
    }
}
