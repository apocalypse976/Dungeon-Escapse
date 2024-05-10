using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    public int gems;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player != null)
            {
                player.AddGems(gems);
                Destroy(gameObject);
              
            }
           
        }
    }
}
