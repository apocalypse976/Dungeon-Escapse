using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject[] _mobileinputs;
    [SerializeField] private GameObject GameOverPanel, _wintrigger;
    [SerializeField] private AudioClip _SelectionClip;
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
        AudioManager.Singleton.PlayAudio(_SelectionClip);
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        AudioManager.Singleton.PlayAudio(_SelectionClip);
        SceneManager.LoadScene(0);
    }
}
