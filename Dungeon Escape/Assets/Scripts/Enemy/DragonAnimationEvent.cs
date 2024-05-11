using UnityEngine;

public class DragonAnimationEvent : MonoBehaviour
{
    private Dragon _dragon;

    private void Start()
    {
        _dragon = transform.parent.GetComponent<Dragon>();
    }
    public void fireFireBall()
    {
        _dragon.Fire();
    }
}
