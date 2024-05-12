using TMPro;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _wintrigger;
    [SerializeField] private TextMeshProUGUI _requirement_Text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Instance.keytoCastle && GameManager.Instance.BossDefeated)
        {
            _wintrigger.SetActive(true);
        }
        else if (!GameManager.Instance.keytoCastle)
        {
            _requirement_Text.text = "You need Key To Casle";
          Invoke("deactivate",5f);
        }
        else if (!GameManager.Instance.BossDefeated)
        {
            _requirement_Text.text = "You need to Defeat Boss";
            Invoke("deactivate", 5f);
        }
    }
    void deactivate()
    {
        _requirement_Text.text = "";
    }
}
