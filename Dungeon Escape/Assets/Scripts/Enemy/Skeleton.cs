using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    public int health { get; set; }

    public override void Init()
    {
        base.Init();
        health = Health;
    }
    public void Damage(int damage)
    {
        if (GameManager.Instance.fireSword)
        {
            health -= damage;
        }
        else
        {
            health--;
        }
        Anim.SetTrigger("Hurt");
        hit = true;
        if (health <= 0)
        {
            Anim.SetTrigger("Death");
            Dead = true;
            Coll.enabled = false;
           
              GameObject diamond=  Instantiate(Diamond, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamonds>().gems= Gems;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Coll.bounds.center + transform.right * Range * transform.localScale.x * Coll_dis,
            new Vector2(Coll.bounds.size.x * Range, Coll.bounds.size.y));
    }
}
