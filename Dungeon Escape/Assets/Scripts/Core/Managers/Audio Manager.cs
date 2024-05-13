using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton { get; private set; }
   [HideInInspector] public AudioSource _sfxsource,_musicSource;
    private const string _sfxKey="SFX Key",_musicKey="MUSIC Key";

    private Slider _musicSlider,_sfxSlider;

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
            _sfxsource = GetComponent<AudioSource>();
            _musicSource= transform.GetChild(0).GetComponent<AudioSource>();
            _musicSlider = GameObject.Find("UI Canvas").transform.GetChild(7).transform.GetChild(2).transform.GetChild(0).GetComponent<Slider>();
            _sfxSlider = GameObject.Find("UI Canvas").transform.GetChild(7).transform.GetChild(3).transform.GetChild(0).GetComponent<Slider>();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
        if ((!PlayerPrefs.HasKey(_sfxKey) && !PlayerPrefs.HasKey(_musicKey)) || (!PlayerPrefs.HasKey(_musicKey) || !PlayerPrefs.HasKey(_sfxKey)))
        {
            PlayerPrefs.SetFloat(_sfxKey, 1f);
            loadSFX();
            PlayerPrefs.SetFloat(_musicKey, 1f);
            loadMusic();
        }
        else
        {
            loadSFX();
            loadMusic();
        }
    }
    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void PlayAudio(AudioClip clip)
    {
        _sfxsource.PlayOneShot(clip);
    }
    public void SfxChange()
    {
        _sfxsource.volume = _sfxSlider.value;
        SaveSFX();
    }
    public void MusicChange()
    {
        _musicSource.volume = _musicSlider.value;
        SaveMusic();
    }
    void loadMusic()
    {
        _musicSlider.value= PlayerPrefs.GetFloat(_musicKey,1 );
    }
    void loadSFX()
    {
        _sfxSlider.value= PlayerPrefs.GetFloat(_sfxKey, 1);
    }
    void SaveMusic()
    {
        PlayerPrefs.SetFloat(_musicKey, _musicSlider.value);
    }
    void SaveSFX()
    {
        PlayerPrefs.SetFloat(_sfxKey, _sfxSlider.value);
    }
}
