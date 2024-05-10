using UnityEngine;
public class Spider : Enemy, IDamagable
{
    [SerializeField] private GameObject _acidPrefab;

    public int health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }
    public override void Movement()
    {
        return;
    }
    public override void Update()
    {
    }
    public void Attack()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity);
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
        if (health <= 0)
        {
            Anim.SetTrigger("Death");
            Dead = true;
            Coll.enabled = false;
            GameObject diamond = Instantiate(Diamond, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamonds>().gems = Gems;
        }
    }
}
