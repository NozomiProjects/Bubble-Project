using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance; // Singleton

    [SerializeField] private int maxLives = 3; // N�mero m�ximo de vidas
    private int currentLives; // Vidas actuales

    private void Awake()
    {
        // Implementar el patr�n Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruir instancias duplicadas
        }
    }

    private void Start()
    {
        ResetLives(); // Inicializar vidas al comienzo
    }

    public void LoseLife()
    {
        currentLives--; // Restar una vida

        if (currentLives <= 0)
        {
            // Si se acaban las vidas, ir a GameOver
            GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
            gameManager.LoadGameOverScene();
        }
    }

    public void ResetLives()
    {
        currentLives = maxLives; // Reiniciar las vidas al m�ximo
    }

    public int GetCurrentLives()
    {
        return currentLives; // Devolver las vidas actuales
    }

    public void LoseAllLives()
    {
        currentLives = 0; // Establecer las vidas a 0 directamente
    }
}
