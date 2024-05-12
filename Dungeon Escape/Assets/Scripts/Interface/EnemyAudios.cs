using UnityEngine;

public class EnemyAudios:MonoBehaviour
{
    [SerializeField] private AudioClip _StepClip, _AttackClip, _HurtClip, _DeathClip;
    public void StepAudio()
    {
        AudioManager.Singleton.PlayAudio(_StepClip);
    }
    public void AttackAudio()
    {
        AudioManager.Singleton.PlayAudio(_AttackClip);
    }
    public void DeathAudio()
    {
        AudioManager.Singleton.PlayAudio(_DeathClip);
    }
    public void HurtAudio()
    {
        AudioManager.Singleton.PlayAudio(_HurtClip);
    }
}
