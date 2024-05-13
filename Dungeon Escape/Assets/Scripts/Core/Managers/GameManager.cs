using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject[] _mobileinputs;
    [SerializeField] private GameObject GameOverPanel, _wintrigger;
    [SerializeField] private AudioClip _SelectionClip;
    [SerializeField] private GameObject _pausePanel,_settingsPanel;
    public bool keytoCastle, fireSword, flightsBoots;
    public bool OnDesktop;
    public bool GameOver;
    public bool BossDefeated;

    private void Awake()
    {
        Instance = this;
        if (Instance == null)
        {
            Debug.LogError("Game Manager is null");
        }
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            OnDesktop = true;
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            OnDesktop = false;
        }
        if (OnDesktop)
        {
            foreach (var _mobileInput in _mobileinputs)
            {
                _mobileInput.gameObject.SetActive(false);
            }
        }
        else if (!OnDesktop)
        {
            foreach (var _mobileInput in _mobileinputs)
            {
                _mobileInput.gameObject.SetActive(true);
            }
        }
        GameOverPanel.SetActive(false);
        _wintrigger.SetActive(false);
        _pausePanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }

    public void gameOver()
    {
        if (GameOver == true)
        {
            GameOverPanel.SetActive(true);
        }
    }
    public void restart()
    {
        Time.timeScale = 1;
        AudioManager.Singleton.PlayAudio(_SelectionClip);
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        AudioManager.Singleton.PlayAudio(_SelectionClip);
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        AudioManager.Singleton.PlayAudio(_SelectionClip);
        Time.timeScale = 0;
        _pausePanel.SetActive(true);

    }
    public void Resume()
    {
        AudioManager.Singleton.PlayAudio(_SelectionClip);
        Time.timeScale = 1;
        _pausePanel.SetActive(false);

    }
    public void Settings()
    {
        AudioManager.Singleton.PlayAudio(_SelectionClip);
        _settingsPanel.SetActive(true);
        _pausePanel.SetActive(false);
    }
    public void Back()
    {
        AudioManager.Singleton.PlayAudio(_SelectionClip);
        _settingsPanel.SetActive(false);
        _pausePanel.SetActive(true);
    }
}
