using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] protected int Gems;
    [SerializeField] protected float Speed;
    [SerializeField] protected Transform Point_A, Point_B;
    [SerializeField] protected GameObject Player,Diamond;
    [SerializeField] private LayerMask _playerlayer;
    [SerializeField] protected float Coll_dis, Range;
    protected bool hit;
    protected Animator Anim;
    protected Vector3 CurrentTarget;
    protected bool Dead;
    protected Collider2D Coll;
    

    public virtual void Init()
    {
        Anim = transform.GetChild(0).GetComponent<Animator>();
        Coll= GetComponent<Collider2D>();
    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && Anim.GetBool("IsCombat"))
        {
            return;
        }
        Movement();
    }
    public virtual void Movement()
    {
        if (CurrentTarget == Point_B.localPosition)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (CurrentTarget == Point_A.localPosition)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (transform.localPosition == Point_A.localPosition)
        {
            CurrentTarget = Point_B.localPosition;
            Anim.SetTrigger("Idle");
        }
        else if (transform.localPosition == Point_B.localPosition)
        {
            CurrentTarget = Point_A.localPosition;
            Anim.SetTrigger("Idle");
        }
        if (!Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !hit&&!Dead&&!PlayerOnSight())
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, CurrentTarget, Speed * Time.deltaTime);
        }
        if (!PlayerOnSight())
        { 
            Anim.SetBool("IsCombat", false);
        }else if (PlayerOnSight())
        {
           Anim.Play("Attack");
            Anim.SetBool("IsCombat", true);
        }
        Vector3 Direction = Player.transform.localPosition - transform.localPosition;
        if (Direction.x < 0 && Anim.GetBool("IsCombat") && !Dead)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Direction.x > 0 && Anim.GetBool("IsCombat") && !Dead)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


    }
    public bool PlayerOnSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(Coll.bounds.center+transform.right*Range*transform.localScale.x*Coll_dis,
            new Vector2(Coll.bounds.size.x*Range,Coll.bounds.size.y),0,Vector2.right,0,_playerlayer);
        return hit.collider != null;
    }
}
