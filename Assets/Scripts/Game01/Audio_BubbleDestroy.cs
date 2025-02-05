using UnityEngine;

public class Audio_BubbleDestroy : MonoBehaviour
{
    //referecias
    //private Player_Aim player;
    //Bubble_Controller bubble;
    //
    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private AudioSource sxf_destroy;
    //[SerializeField] private AudioSource sfx_shoot;

    private void Start() {
        //player = FindAnyObjectByType<Player_Aim>();
        sxf_destroy = GetComponentInChildren<AudioSource>();
    }
    private void Update() {
        bubbles = GameObject.FindGameObjectsWithTag("bubble");
        DestroyBubble();
        //PlayerShoot();
    }
    private void DestroyBubble() {
        foreach (GameObject bubble in bubbles) {
            if (bubble.GetComponent<Bubble_Controller>().RatePoint <= 0) {
            sxf_destroy.Play();
            }
        }
    }
    /*private void PlayerShoot() {
        if (player.IsAttack && Time.time < player.Nextshot){
            sfx_shoot.Play();
        }
    }*/
}
