using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable hit = collision.GetComponent<IDamagable>();
        if (hit != null && _canDamage)
        {
            hit.Damage(20);
            _canDamage = false;
        }
        Invoke("ResetDamage", 0.5f);
    }
    void ResetDamage()
    {
        _canDamage = true;
    }
}
