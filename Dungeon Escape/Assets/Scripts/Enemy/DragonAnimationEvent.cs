using UnityEngine;

public class DragonAnimationEvent : MonoBehaviour
{
    private Dragon _dragon;
    [SerializeField] private AudioClip _AttackClip, _DeathClip;

    private void Start()
    {
        _dragon = transform.parent.GetComponent<Dragon>();
    }
    public void fireFireBall()
    {
        _dragon.Fire();
    }
    public void AttackClip()
    {
        AudioManager.Singleton.PlayAudio(_AttackClip);
    }
    public void DeathClip()
    {
        AudioManager.Singleton.PlayAudio(_DeathClip);
    }
}
