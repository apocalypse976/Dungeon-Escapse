using UnityEngine;

public class Diamonds : MonoBehaviour
{
    public int gems;
    [SerializeField] private AudioClip _pickUpClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                AudioManager.Singleton.PlayAudio(_pickUpClip);
                player.AddGems(gems);
                Destroy(gameObject);

            }

        }
    }
}
