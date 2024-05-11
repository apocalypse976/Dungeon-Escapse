using UnityEngine;

public class AcidAttck : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    public virtual void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamagable hit = collision.GetComponent<IDamagable>();
            if (hit != null)
            {
                hit.Damage(2);
                Destroy(gameObject);
            }
        }
    }
}
