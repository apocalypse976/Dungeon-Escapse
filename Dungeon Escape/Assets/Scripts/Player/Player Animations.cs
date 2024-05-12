using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _anim;
    private Animator _sanim;
    [SerializeField] private AudioClip _SwordClip,_fireSwordClip,JumpClip,_deathClip;
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
    public void FireSwordSwing()
    {
        AudioManager.Singleton.PlayAudio(_fireSwordClip);
    }
    public void SwordSwing()
    {
        AudioManager.Singleton.PlayAudio(_SwordClip);
    }
    public void JumpAudio()
    {
        AudioManager.Singleton.PlayAudio(JumpClip);
    }
    public void DeathAudio()
    {
        AudioManager.Singleton.PlayAudio(_deathClip);
    }
}
