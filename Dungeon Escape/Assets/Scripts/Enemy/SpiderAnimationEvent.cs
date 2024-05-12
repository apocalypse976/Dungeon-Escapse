using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider _spider;
    [SerializeField] private AudioClip _AttackClip,_DeathClip;
    private void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        _spider.Attack();
    }
    public void AttackSound()
    {
        AudioManager.Singleton.PlayAudio(_AttackClip);
    }
    public void DeathSound()
    {
        AudioManager.Singleton.PlayAudio(_DeathClip);
    }
}
