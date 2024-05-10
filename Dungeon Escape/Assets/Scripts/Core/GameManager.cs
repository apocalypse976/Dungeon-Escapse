using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject[] _mobileinputs; 
    public bool keytoCastle,fireSword,flightsBoots;
    public bool OnDesktop;

    private void Awake()
    {
        Instance = this;
        if (Instance == null)
        {
            Debug.LogError("Game Manager is null");
        }
        if(SystemInfo.deviceType== DeviceType.Desktop)
        {
            OnDesktop = true;
        }
        else if(SystemInfo.deviceType==DeviceType.Handheld)
        {
            OnDesktop=false;
        }
        if (OnDesktop)
        {
            foreach (var _mobileInput in _mobileinputs)
            {
                _mobileInput.gameObject.SetActive(false);
            }
        }
        else if (!OnDesktop)
        {
            foreach (var _mobileInput in _mobileinputs)
            {
                _mobileInput.gameObject.SetActive(true);
            }
        }
    }


}
