using UnityEngine;
using UnityEngine.UI;
public class Dragon : Enemy, IDamagable
{
    public int health { get; set; }
    private float _cooldownTime=2f,_attacktime;
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Image healthBar;

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
        if ( Mathf.Abs( distance) <= 15)
        {
            if(Time.time>_attacktime)
            {
                _attacktime =_cooldownTime+ Time.time;
                Anim.SetTrigger("Attack");
            }
           
        }
        healthBar.fillAmount = health*0.01f;
    }
    public void Damage(int damage)
    {
        if(GameManager.Instance.fireSword)
        {
            health -= damage;
        }
        else
        {
            health--;
        }
       
        if (health <= 0)
        {
            Anim.SetTrigger("Die");
            Coll.enabled = false;
            GameManager.Instance.BossDefeated = true;
        }
    }
    public void Fire()
    {
        Instantiate(_fireBall, _firePoint.position, Quaternion.identity);
    }
   
}
