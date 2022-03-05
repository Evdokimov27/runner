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


    public static int coins;
    public static int diamond;




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

    public void DailyReward()
    {
        int day = PlayerPrefs.GetInt("day");
        if (day == 1)
        {
            coins += 15;
            
        }
        if (day == 2)
        {
            coins += 20;
            
        }
        if (day == 3)
        {
            diamond += 1;
            
        }
        if (day == 4)
        {
            coins += 50;
            
        }
        if (day == 5)
        {
            diamond += 1;
            
        }
        if (day == 6)
        {
            coins += 100;
            
        }
        if (day == 7)
        {
            coins += 150;
            
        }
        if (day == 8)
        {
            diamond += 3;
            
        }
        if (day == 9)
        {
            coins += 200;
            
        }
        if (day == 10)
        {
            diamond += 5;
            
        }
        if (day == 11)
        {
            diamond += 5;
            
        }
        if (day == 12)
        {
            coins += 300;
            
        }
        if (day == 13)
        {
            diamond += 10;
            
        }
        if (day == 14)
        {
            coins += 450;
            
        }
        if (day == 15)
        {
            StockCheck[3] = true;
            info[3].inStock = true;
            Save();
            coinsText.text = coins.ToString();
        }
        coinsText.text = coins.ToString();
        diamondText.text = diamond.ToString();
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("diamond", diamond);
    }
    public void BuyButtonAction()
    {
        if (buyBttn.interactable && !info[index].inStock && info[index].sell_diamond)
        {
            if (diamond >= int.Parse(priceText.text))
            {
                close.SetActive(false);
                diamond -= int.Parse(priceText.text);
                coinsText.text = coins.ToString();
                PlayerPrefs.SetInt("diamond", diamond);
                StockCheck[index] = true;
                info[index].inStock = true;
                priceText.text = "¬€¡–¿“‹";
                Save();
            }
        }
        if (buyBttn.interactable && !info[index].inStock && !info[index].sell_diamond)
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