using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gemsCounttxt,_gemstext;
    [SerializeField] private GameObject _shop,_shopButton;
    [SerializeField] private Image _selectionImg;
    [SerializeField] private Image[] _livesImg;
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UI Manager is NULL");
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _shop.SetActive(false);
        _shopButton.SetActive(false);
        _selectionImg.gameObject.SetActive(false);
    }

    public void OnShop(int gems)
    {
        _gemsCounttxt.text = " " + gems + "G";
    }
    public void UpdateSelection(float Ypos)
    {   _selectionImg.gameObject.SetActive(true);
        _selectionImg.rectTransform.anchoredPosition = new Vector2(_selectionImg.rectTransform.anchoredPosition.x, Ypos);
    }
    public void UpdateGemsCount(int gems)
    {
        _gemstext.text = "" + gems;
    }
    public void UpdateLives(int lives)
    {
        for(int i = 0;i<= _livesImg.Length; i++) 
        {
            if (i == lives)
            {
                _livesImg[i].gameObject.SetActive(false);
            }
        }
    }

}
