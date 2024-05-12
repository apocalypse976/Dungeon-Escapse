using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private Player _player;
    private PlayerAnimations _anim;
    [SerializeField] private Image[] _livesImg;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _anim = GameObject.FindWithTag("Player").GetComponent<PlayerAnimations>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contactCount>0 && _player != null)
        {
            _player.health = 0;
            _anim.DeathAnim();
            foreach (var item in _livesImg)
            {
                item.gameObject.SetActive(false);
            }
            _player.enabled = false;
            _anim.enabled = false;
            GameManager.Instance.GameOver = true;
            GameManager.Instance.gameOver();
        }
    }
}
