using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Lista de escenas de juego
    private string[] gameScenes = { "Game01", "Game03" };

    // M�todo para cargar una escena aleatoria
    public void TutorialLoadRandomGameScene()
    {
        // Generar un �ndice aleatorio
        int randomIndex = Random.Range(0, gameScenes.Length);

        // Obtener el nombre de la escena aleatoria
        string randomSceneName = gameScenes[randomIndex];

        // Usar el SceneTransitionController para cargar la escena con transici�n
        SceneTransitionController.Instance.TransitionToScene(randomSceneName);
    }
}
