using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton { get; private set; }
   [HideInInspector] public AudioSource _source;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else if(Singleton != null)
        {
            Destroy(gameObject);
        }


        try
        {
            _source = GetComponent<AudioSource>();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void PlayAudio(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
}
