using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject GameMenu;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject Rewards;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject CameraMenu;
    [SerializeField] private Text coinsText;
    [SerializeField] private int coins;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void Play()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        CameraMenu.SetActive(false);
        GameMenu.SetActive(false);
        Player.SetActive(true);
        UI.SetActive(true);
    }
    public void SkinShop()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        GameMenu.SetActive(false);
        Shop.SetActive(true);

    
        
    }
    public void goMenu()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        GameMenu.SetActive(true);
        Shop.SetActive(false);


    }
    public void DailyReward()
    {
        coins = PlayerPrefs.GetInt("coins");
        GameMenu.SetActive(false);
        Rewards.SetActive(true);



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
