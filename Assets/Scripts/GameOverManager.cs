using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour 
{
    public TMP_Text finalScoreText; // Referencia al texto de puntaje final

    private void Start()
    {
        // Obtener el puntaje final desde el ScoreManager
        int finalScore = ScoreManager.Instance.GetScore();

        // Actualizar el texto para mostrar el puntaje final
        finalScoreText.text = "Tu puntaje final es: " + finalScore.ToString();

        // Reiniciar el puntaje para la próxima partida
        ScoreManager.Instance.ResetScore();

        LifeManager.Instance.ResetLives(); // Reiniciar las vidas

    }

    // Método para cargar la escena de Start Menu
    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}