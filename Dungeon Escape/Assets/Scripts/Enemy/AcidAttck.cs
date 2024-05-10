using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidAttck : MonoBehaviour
{
    [SerializeField] private float _speed;
 
    private void Start()
    {
        Destroy(gameObject,5f);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamagable hit = collision.GetComponent<IDamagable>();
            if(hit != null)
            {
                hit.Damage(2);
                Destroy(gameObject);
            }
        }
    }
}
