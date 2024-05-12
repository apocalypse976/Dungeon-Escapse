using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shop, _shopButton;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AudioClip _selectedClip,_collectedClip;
    private int _itemsId, _price;
    private Player player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _shop.SetActive(true);
            _shopButton.SetActive(true);
            UIManager.Instance.OnShop(player.Diamond);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _shop.SetActive(false);
            _shopButton.SetActive(false);
        }
    }
    public void Selection(int itemId)
    {
        switch (itemId)
        {
            case 0://Key
                UIManager.Instance.UpdateSelection(72);
                AudioManager.Singleton.PlayAudio(_selectedClip);
                _price = 500;
                break;
            case 1: //Boots
                UIManager.Instance.UpdateSelection(-28);
                AudioManager.Singleton.PlayAudio(_selectedClip);
                _price = 400;
                break;
            case 2: //Flame Sword
                UIManager.Instance.UpdateSelection(-118);
                AudioManager.Singleton.PlayAudio(_selectedClip);
                _price = 700;
                break;
        }
        _itemsId = itemId;
    }
    public void BuyItems()
    {
        if (_itemsId == 0 && player.Diamond >= _price)
        {
            GameManager.Instance.keytoCastle = true;
            player.Diamond -= _price;
            UIManager.Instance.UpdateGemsCount(player.Diamond);
            AudioManager.Singleton.PlayAudio(_collectedClip);
            _text.text = "You have sucessully bought Key to Castle \n" + "Gems Left: " + player.Diamond + " G";
        }
        else if (_itemsId == 1 && player.Diamond >= _price)
        {
            GameManager.Instance.flightsBoots = true;
            player.Diamond -= _price;
            _text.text = "You have sucessully bought Boots of Flight \n" + "Gems Left: " + player.Diamond + " G";
            UIManager.Instance.UpdateGemsCount(player.Diamond);
            AudioManager.Singleton.PlayAudio(_collectedClip);
        }
        else if (_itemsId == 2 && player.Diamond >= _price)
        {
            GameManager.Instance.fireSword = true;
            player.Diamond -= _price;
            _text.text = "You have sucessully bought Flame Sword \n" + " Gems Left: " + player.Diamond + " G";
            UIManager.Instance.UpdateGemsCount(player.Diamond);
            AudioManager.Singleton.PlayAudio(_collectedClip);
        }
        else
        {
            _text.text = "You do not have sufficient gems \n" + "Gems Left: " + player.Diamond + " G";
        }
    }
}
