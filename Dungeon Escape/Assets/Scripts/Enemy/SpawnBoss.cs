using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Instance.keytoCastle)
        {
           Instantiate(_boss, new Vector3(124,-6,0),Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

}
