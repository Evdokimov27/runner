using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinShop : MonoBehaviour
{
    public Skin[] info;
    public static bool[] StockCheck;
    [SerializeField] private GameObject close;
    [SerializeField] private Sprite img_coin;
    [SerializeField] private Sprite img_diamond;
    [SerializeField] private Sprite img_claim;

    public Button buyBttn;
    public Text priceText;
    public Text coinsText;
    public Text diamondText;
    public Transform player;
    public static int index;


    public int coins;
    public int diamond;




    private void Awake()
    {
        diamond = PlayerPrefs.GetInt("diamond");
        coins = PlayerPrefs.GetInt("coins");
        index = PlayerPrefs.GetInt("chosenSkin");
        coinsText.text = coins.ToString();
        diamondText.text = diamond.ToString();

        StockCheck = new bool[53];
        StockCheck = new bool[53];
        if (PlayerPrefs.HasKey("StockArray"))
            StockCheck = PlayerPrefsX.GetBoolArray("StockArray");
        else
            StockCheck[0] = true;

        info[index].isChosen = true;

        for (int i = 0; i < info.Length; i++)
        {
            info[i].inStock = StockCheck[i];

            if (i == index)
            {
                PlayerPrefs.SetInt("skin", i);
                player.GetChild(i).gameObject.SetActive(true);
                close.SetActive(false);

            }
            else
            {
                player.GetChild(i).gameObject.SetActive(false);
            }
        }

        priceText.text = "¬€¡–¿Õ";
        buyBttn.interactable = false;
    }

    public void Save()
    {
        PlayerPrefsX.SetBoolArray("StockArray", StockCheck);
    }

    public void ScrollRight()
    {
        if (index < player.childCount)
        {
            index++;
            
            if (info[index].inStock && info[index].isChosen)
            {
                priceText.text = "¬€¡–¿Õ";
                buyBttn.interactable = false;
                close.SetActive(false);
                buyBttn.image.sprite = img_claim;
            }
            else if (info[index].dailyReward && !info[index].inStock)
            {
                priceText.text = "≈∆≈ƒÕ≈¬Õ¿ﬂ Õ¿√–¿ƒ¿".ToString();
                buyBttn.interactable = false;
                close.SetActive(true);
                buyBttn.image.sprite = img_claim;
            }
            else if (info[index].sell_diamond && !info[index].inStock)
            {
                priceText.text = info[index].cost_diamond.ToString();
                buyBttn.interactable = true;
                close.SetActive(true);
                buyBttn.image.sprite = img_diamond;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost_coin.ToString();
                buyBttn.interactable = true;
                close.SetActive(true);
                buyBttn.image.sprite = img_coin;
            }

            else if (info[index].inStock && !info[index].isChosen)
            {
                priceText.text = "¬€¡–¿“‹";
                buyBttn.interactable = true;
                close.SetActive(false);
                buyBttn.image.sprite = img_claim;
            }

            for (int i = 0; i < player.childCount; i++)
                player.GetChild(i).gameObject.SetActive(false);

            player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void ScrollLeft()
    {
        if (index > 0)
        {
            index--;

            if (info[index].inStock && info[index].isChosen)
            {
                priceText.text = "¬€¡–¿Õ";
                buyBttn.interactable = false;
                close.SetActive(false);
                buyBttn.image.sprite = img_claim;
            }

            else if (info[index].dailyReward && !info[index].inStock)
            {
                priceText.text = "≈∆≈ƒÕ≈¬Õ¿ﬂ Õ¿√–¿ƒ¿".ToString();
                buyBttn.interactable = false;
                close.SetActive(true);
                buyBttn.image.sprite = img_claim;
            }
            else if (info[index].sell_diamond && !info[index].inStock)
            {
                priceText.text = info[index].cost_diamond.ToString();
                buyBttn.interactable = true;
                close.SetActive(true);
                buyBttn.image.sprite = img_diamond;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost_coin.ToString();
                buyBttn.interactable = true;
                close.SetActive(true);
                buyBttn.image.sprite = img_coin;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                priceText.text = "¬€¡–¿“‹";
                buyBttn.interactable = true;
                close.SetActive(false);
                buyBttn.image.sprite = img_claim;
            }

            for (int i = 0; i < player.childCount; i++)
                player.GetChild(i).gameObject.SetActive(false);

            player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void RewardSkin()
    {
        int day = PlayerPrefs.GetInt("day");
        if (day == 1)
        {
            coins = 150;
            coinsText.text = coins.ToString();
        }
        if (day == 2)
        {
            coins = 200;
            coinsText.text = coins.ToString();

        }
        if (day == 3)
        {
            coins = 500;
            coinsText.text = coins.ToString();

        }
        if (day == 4)
        {
            coins = 750;
            coinsText.text = coins.ToString();

        }
        if (day == 5)
        {
            coins = 1000;
            coinsText.text = coins.ToString();
        }
        if (day == 6)
        {
            coins = 1250;
            coinsText.text = coins.ToString();
        }
        if (day == 7)
        {
            coins = 1500;
            coinsText.text = coins.ToString();
        }
        if (day == 8)
        {
            coins = 1750;
            coinsText.text = coins.ToString();
        }
        if (day == 9)
        {
            coins = 2000;
            coinsText.text = coins.ToString();
        }
        if (day == 10)
        {
            coins = 2500;
            coinsText.text = coins.ToString();
        }
        if (day == 11)
        {
            coins = 3000;
            coinsText.text = coins.ToString();
        }
        if (day == 12)
        {
            coins = 4000;
            coinsText.text = coins.ToString();
        }
        if (day == 13)
        {
            coins = 5000;
            coinsText.text = coins.ToString();
        }
        if (day == 14)
        {
            coins = 7500;
            coinsText.text = coins.ToString();
        }
        if (day == 15)
        {
            coins += 1;
            StockCheck[3] = true;
            info[3].inStock = true;
            Save();
            coinsText.text = coins.ToString();
        }
        PlayerPrefs.SetInt("coins", coins);
    }
    public void BuyButtonAction()
    {
       
        if (buyBttn.interactable && !info[index].inStock)
        {
            if (coins >= int.Parse(priceText.text))
            {
                close.SetActive(false);
                coins -= int.Parse(priceText.text);
                coinsText.text = coins.ToString();
                PlayerPrefs.SetInt("coins", coins);
                StockCheck[index] = true;
                info[index].inStock = true;
                priceText.text = "¬€¡–¿“‹";
                Save();
            }
        }

        if (buyBttn.interactable && !info[index].isChosen && info[index].inStock)
        {
            close.SetActive(false);
            PlayerPrefs.SetInt("chosenSkin", index);
            buyBttn.interactable = false;
            priceText.text = "¬€¡–¿Õ";
            RestartLevel();
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}


[System.Serializable]
public class Skin
{
    public int cost_coin;
    public int cost_diamond;
    public bool sell_diamond;
    public bool inStock;
    public bool isChosen;
    public bool dailyReward;
}