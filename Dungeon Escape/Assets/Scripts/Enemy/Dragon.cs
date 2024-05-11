using UnityEngine;
public class Dragon : Enemy, IDamagable
{
    public int health { get; set; }
    private float _cooldownTime=1f;
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private Transform _firePoint;

    public override void Init()
    {
        base.Init();
        health = Health;
          
    }
    public override void Movement()
    {
       
    }
    public override void Update()
    {
      float distance= Vector3.Distance(transform.position,Player.transform.position);
        Debug.Log(distance);
        if ( Mathf.Abs( distance) <= 15)
        {
            if(_cooldownTime <Time.time)
            {
                _cooldownTime += Time.time;
                Anim.SetTrigger("Attack");
            }
           
        }
    }
    public void Damage(int damage)
    {
        if(GameManager.Instance.fireSword)
        {
            Health -= damage;
        }
        else
        {
            Health--;
        }
       
        if (Health <= 0)
        {
            Anim.SetTrigger("Die");
            Coll.enabled = false;
        }
    }
    public void Fire()
    {
        Instantiate(_fireBall, _firePoint.position, Quaternion.identity);
    }
   
}
