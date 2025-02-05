using Unity.VisualScripting;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }
    private void Update() {
        //verificar si el gameobject esta fuara de la vista de la camara
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1) Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "bubble") Destroy(this.gameObject);
    }
}
