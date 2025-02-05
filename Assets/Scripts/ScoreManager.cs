using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score; // Variable para almacenar el puntaje

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia del ScoreManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruir el objeto duplicado
        }
    }

    public void AddScore(int points)
    {
        score += points; // Sumar puntos al puntaje
    }

    public int GetScore()
    {
        return score; // Obtener el puntaje actual
    }

    public void ResetScore()
    {
        score = 0; // Reiniciar el puntaje
    }
}