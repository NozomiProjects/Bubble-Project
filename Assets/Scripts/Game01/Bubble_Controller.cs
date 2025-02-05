using TMPro;
using UnityEngine;

public class Bubble_Controller : MonoBehaviour
{
    //Variables para destruccion al salir de la pantalla
    private Camera mainCamera;
    [SerializeField] private GameObject bubble;
    
    ///
    [SerializeField] private int minRatePoint = 1;
    [SerializeField] private int maxRatePoint = 5;
    private int ratePoint;
    public int RatePoint { get { return ratePoint; } }
    private int point; ////PARA EL PUNTAJE
    //private int Point { get { return this.point; } } /// PARA EL PUNTAJE
    //Variables para el texto
    [SerializeField] private TMP_Text pointText;
    //variables de particulas
    [SerializeField] private ParticleSystem pop;
    //Audio variables
    //private GameObject audio;
    
    private void Start() {
        mainCamera = Camera.main;
        ratePoint = Random.Range(minRatePoint,maxRatePoint);
        point = ratePoint;
    }
    private void Update() {
        ShowRate();
        DestroyEvent();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "bullet") {
            pop.Play();
            ratePoint--;
        }
        if (other.gameObject.tag == "bound") Destroy(this.gameObject);
    }
    private void ShowRate() {
        pointText.text = "" + ratePoint.ToString();
    }
    private void DestroyEvent() {
        if (ratePoint <= 0) {
            GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
            gameManager.AddPoints(point);
            Destroy(this.gameObject);
        }
    }
    
}
