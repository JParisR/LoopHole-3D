using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance = null;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else if (instance == this)
        {
            return;
        } else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
