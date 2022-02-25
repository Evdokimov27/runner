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
    [SerializeField] private GameObject Cards;
    [SerializeField] private GameObject CameraMenu;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text diamondText;
    [SerializeField] private int coins;
    [SerializeField] private int diamond;


    // Start is called before the first frame update

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
        coinsText.text = coins.ToString();
        GameMenu.SetActive(false);
        Shop.SetActive(true);

    
        
    }
    public void deleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
    public void goMenu()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        GameMenu.SetActive(true);
        Shop.SetActive(false);
        Rewards.SetActive(false);


    }
    public void Card()
    {
        GameMenu.SetActive(false);
        Cards.SetActive(true);
    }
    public void DailyReward()
    {
        GameMenu.SetActive(false);
        Rewards.SetActive(true);



    }


    // Update is called once per frame
    void Update()
    {
        coins = PlayerPrefs.GetInt("coins");
    }
}
