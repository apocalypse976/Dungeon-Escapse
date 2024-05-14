using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip _selectionClip;
    [SerializeField] private GameObject _settingsPanel, _audioPanel, _creditsPanel;
    private void Awake()
    {
        _settingsPanel.SetActive(false);
        _audioPanel.SetActive(false);
        _creditsPanel.SetActive(false);
    }
    public void StartButton()
    {
        AudioManager.Singleton.PlayAudio(_selectionClip);
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void Settings()
    {
        AudioManager.Singleton.PlayAudio(_selectionClip);
        _settingsPanel.SetActive(true);
    }
    public void Audio()
    {
        _settingsPanel.SetActive(false);
        _audioPanel.SetActive(true);

    }
    public void credits()
    {
        _settingsPanel.SetActive(false);
        _creditsPanel.SetActive(true);
    }
    public void Back()
    {
        AudioManager.Singleton.PlayAudio(_selectionClip);
        if(_settingsPanel.activeInHierarchy)
        {
            _settingsPanel.SetActive(false);
        }
        else if (_audioPanel.activeInHierarchy)
        {
            _audioPanel.SetActive(false);
        }
        else if( _creditsPanel.activeInHierarchy)
        {
            _creditsPanel.SetActive(false);
        }

          
    }
}
