using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using System.Collections;
using UnityEngine.UI; // Aseg�rate de incluir esto para usar UI

public class GameManager : MonoBehaviour
{
    [SerializeField] private float countdownTime = 5f; // Tiempo de cuenta atr�s
    public TMP_Text countdownText; // Referencia al texto de cuenta atr�s
    public TMP_Text scoreText; // Referencia al texto de puntaje
    public TMP_Text livesText; // Referencia al texto de vidas

    private void Start()
    {
        // Iniciar la cuenta atr�s
        StartCoroutine(CountdownToNextScene());

        // Actualizar el texto de puntaje al inicio
        UpdateScoreText();

        // Actualizar el texto de vidas al inicio
        UpdateLivesText();
    }
    private void Update() {
        UpdateLivesText();
        UpdateScoreText();
    }
    private IEnumerator CountdownToNextScene()
    {
        while (countdownTime > 0)
        {
            countdownText.text = "Tiempo restante: " + Mathf.Ceil(countdownTime).ToString();
            countdownTime -= Time.deltaTime;
            yield return null; // Esperar un frame
        }

        // Cargar una escena aleatoria despu�s de que termine la cuenta atr�s
        LoadRandomGameScene();
    }

    private void LoadRandomGameScene()
    {
        // Lista de escenas de juego
        string[] gameScenes = { "Game01", "Game03" };
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Generar un �ndice aleatorio
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, gameScenes.Length);
        } while (gameScenes[randomIndex] == currentSceneName); // Asegurarse de que no sea la misma escena

        // Agregar un punto al puntaje antes de cambiar de escena
        ScoreManager.Instance.AddScore(1);

        // Usar el SceneTransitionController para cargar la escena con transici�n
        SceneTransitionController.Instance.TransitionToScene(gameScenes[randomIndex]);
    }

    // M�todo para cargar la escena de Game Over
    public void LoadGameOverScene()
    {
        // Cambia "" por el nombre de la escena a la que quieras ir
        SceneTransitionController.Instance.TransitionToScene("GameOver");
    }

    public void AddPoints(int points)
    {
        ScoreManager.Instance.AddScore(points); // A�adir puntos al puntaje
        UpdateScoreText(); // Actualizar la UI
    }

    public void LoseLife()
    {
        LifeManager.Instance.LoseLife(); // Restar vida desde el LifeManager
        UpdateLivesText(); // Actualizar las vidas en la UI
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Puntaje: " + ScoreManager.Instance.GetScore().ToString();
    }

    public void UpdateLivesText()
    {
        livesText.text = "Vidas: " + LifeManager.Instance.GetCurrentLives().ToString();
    }
}
