using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip _selectionClip;
    public void StartButton()
    {
        AudioManager.Singleton.PlayAudio(_selectionClip);
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
