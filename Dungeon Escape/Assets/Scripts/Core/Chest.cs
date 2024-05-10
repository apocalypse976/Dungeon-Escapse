using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IDamagable
{
    public int health { get; set; }
    private Animator _anim;
    private Player _player;
    [SerializeField] private GameObject _diamondPrefab;
    private void Awake()
    {
        health = 1;
        _anim = GetComponent<Animator>();
        _player=GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public void Damage(int damage)
    {
        health--;
        if(health <= 0)
        {
            _anim.SetTrigger("Open");
            Instantiate(_diamondPrefab,transform.position,Quaternion.identity);
            _player.Diamond += 50;

        }
    }
}
