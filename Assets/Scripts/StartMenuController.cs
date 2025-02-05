using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Cambia "Tutorial" por el nombre de la escena a la que quieras ir
        SceneTransitionController.Instance.TransitionToScene("Tutorial");
    }

    public void OpenCloseSettings(GameObject canva)
    {
        canva.SetActive(true);
        this.gameObject.SetActive(false);
        // Aqu� puedes abrir la escena de configuraci�n o mostrar un panel
        //Debug.Log("Abrir Configuraci�n");
    }
    /*public void BackMenu(){

    }*/

    public void ExitGame()
    {
        // Si estamos en el editor, detener la ejecuci�n
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Salir del juego en una construcci�n
        Application.Quit();
#endif
        Debug.Log("Salir del juego");
    }
}
