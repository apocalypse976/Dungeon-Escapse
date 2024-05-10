using UnityEngine;

public class Moss_Giant : Enemy, IDamagable
{
    public int health { get; set; }
     private float range,coll_dis;
    public override void Init()
    {
        base.Init();
        health = Health;
        range = Range;
        coll_dis = Coll_dis;
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
            GameObject diamond = Instantiate(Diamond, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamonds>().gems = Gems;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Coll.bounds.center + transform.right * range * transform.localScale.x * coll_dis,
            new Vector2(Coll.bounds.size.x * range, Coll.bounds.size.y));
    }

}
