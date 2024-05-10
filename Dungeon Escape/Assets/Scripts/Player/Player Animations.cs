using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _anim;
    private Animator _sanim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _sanim = transform.GetChild(0).GetComponentInChildren<Animator>();
    }
    public void moveAnim(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }
    public void jumpAnim()
    {
        _anim.SetTrigger("Jump");
    }
    public void attackAnim()
    {
        _anim.SetTrigger("Attack");
        _sanim.SetTrigger("SwordAnimation");
    }
    public void DeathAnim()
    {
        _anim.SetTrigger("Death");
    }
    public void hit()
    {
        _anim.SetTrigger("Hit");
    }
    public void FireSwing()
    {
        _anim.SetTrigger("FlameSword");
    }
}
