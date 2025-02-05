using UnityEngine;

public class Bubble_Generator : MonoBehaviour {
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private Transform bubbleGenerator;
    [SerializeField] private Transform target;
    [SerializeField] private float bubbleSpeed;
    [SerializeField] private float minBubbleRate;
    [SerializeField] private float maxBubbleRate;
    private float nextGen;
    /*private void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }*/
    private void Update() {
        Aiming();
        float rate = Random.Range(minBubbleRate,maxBubbleRate);
        if(Time.time >= nextGen){
            BubbleGenerate();
            nextGen = Time.time + rate;
        }
    }
    private void BubbleGenerate() {
        //crea el objeto y asigna el objetivo
        GameObject bubble = Instantiate(bubblePrefab, bubbleGenerator.position, bubbleGenerator.rotation);
        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();

        if (rb != null) rb.linearVelocity = bubbleGenerator.right * bubbleSpeed;
    }
    private void Aiming() {
        Vector3 playerPos = target.position;
        playerPos.z = 0;
        Vector2 dir = (playerPos - bubbleGenerator.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f ,0f ,angle);
    }
}
