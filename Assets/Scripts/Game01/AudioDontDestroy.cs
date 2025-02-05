using UnityEngine;

public class AudioDontDestroy : MonoBehaviour
{
    public static AudioDontDestroy instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
}
