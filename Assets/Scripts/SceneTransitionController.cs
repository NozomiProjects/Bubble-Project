using System.Collections;
using UnityEngine;

public class SceneTransitionController : MonoBehaviour
{
    public static SceneTransitionController Instance;

    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private CanvasGroup transitionCanvasGroup;
    [SerializeField] private float transitionDuration = 0.6f;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(PerformSceneTransition(sceneName));
    }

    private IEnumerator PerformSceneTransition(string sceneName)
    {
        // Asegurarse de que el panel de transici�n est� activo
        transitionCanvasGroup.alpha = 1; // Panel completamente opaco
        transitionCanvasGroup.interactable = true;
        transitionCanvasGroup.blocksRaycasts = true;

        // Ejecutar la animaci�n de salida
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(transitionDuration); // Esperar a que termine la animaci�n

        // Cargar la nueva escena
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        // Ejecutar la animaci�n de entrada
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionDuration); // Esperar a que termine la animaci�n

        // Ocultar el panel de transici�n
        transitionCanvasGroup.alpha = 0; // Panel completamente transparente
        transitionCanvasGroup.interactable = false;
        transitionCanvasGroup.blocksRaycasts = false;
    }
}
