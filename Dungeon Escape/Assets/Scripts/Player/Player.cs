using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [Header("Player Speed")]
    [SerializeField] private float _speed = 5f;

    [Header("Player Jump")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpforce = 5f;

    [Header("Diamond")]
     public int Diamond;

    private Rigidbody2D _rb;
    private Collider2D _coll;
    private PlayerAnimations _anim;
    private float _move;
    private Vector2 _playermove;
    public int health { get;set;} 

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        _anim = GetComponent<PlayerAnimations>();
        health = 4;
    }
    private void Update()
    {
        Movements();
        if (GameManager.Instance.OnDesktop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
        }        
    }
    public void Attack()
    {
        if (onGround() && _move == 0)
        {
            if (GameManager.Instance.fireSword)
            {
                _anim.FireSwing();
            }
            else
            {
              _anim.attackAnim();
            }
           
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        _playermove= context.ReadValue<Vector2>();
    }
    void Movements()
    {
        _move = _playermove.x;
        _rb.velocity = new Vector2(_move * _speed, _rb.velocity.y);
        _anim.moveAnim(_move);
        Flip(_move);
    }
    public void jump()
    {
        if (onGround())
        {
            if(GameManager.Instance.flightsBoots)
            {
                _rb.AddForce(Vector2.up * _jumpforce*2.3f, ForceMode2D.Impulse);
                _anim.jumpAnim();
            }
            else
            {
                _rb.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
                _anim.jumpAnim();
            }
           
        }
      
    }
    bool onGround()
    {
        RaycastHit2D groundray = Physics2D.BoxCast(_coll.bounds.min, _coll.bounds.size, 0, Vector2.down, 0f, _groundLayer.value);
        return groundray.collider != null;
    }
    void Flip(float Move)
    {
        if (Move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void Damage(int damage)
    {
        health--;
        UIManager.Instance.UpdateLives(health);
        if (health <= 0)
        {
            _anim.DeathAnim();
           _coll.enabled = false;
            _rb.isKinematic = true;
            GameManager.Instance.GameOver = true;
            GameManager.Instance.gameOver();

        }
    }
    public void AddGems(int gems)
    {
        Diamond += gems;
        UIManager.Instance.UpdateGemsCount(Diamond);
    }
}
