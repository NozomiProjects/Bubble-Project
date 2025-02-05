using UnityEngine;
using UnityEngine.UI;

public class Audio_VolController : MonoBehaviour
{
    [SerializeField] private GameObject sliderVol;
    private Slider controlVol;
    [SerializeField] private GameObject[] audios; 

    private void Start() {
        sliderVol = GameObject.FindGameObjectWithTag("volSfx");
        controlVol = sliderVol.GetComponent<Slider>();
        controlVol.value = PlayerPrefs.GetFloat("volumeSave", 0.2f);
    }
    private void Update() {
        audios = GameObject.FindGameObjectsWithTag("sfx");
        foreach (GameObject aud in audios) {
            aud.GetComponent<AudioSource>().volume = controlVol.value;
        }
    }
    public void SaveVolume() {
        PlayerPrefs.SetFloat("volumeSave", controlVol.value);
    }
}
