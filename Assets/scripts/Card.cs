using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Card : MonoBehaviour
{
    public float msToWait = 0f;
    public Text Timer;
    public Button[] openCard;

    public int ind;
    [SerializeField] public Text coinsText;
    public int coins;
    public int diamond;
    [SerializeField] public Text diamondText;
    private ulong cardOpen = ((ulong)1);
    [SerializeField] private Sprite img_coin;
    [SerializeField] private Sprite img_diamond;
    [SerializeField] private Sprite background; 
     [SerializeField] public int randomizer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins = PlayerPrefs.GetInt("coins");
        diamond = PlayerPrefs.GetInt("diamond");
        coinsText.text = coins.ToString();
        diamondText.text = diamond.ToString();
        for (int index = 0; index < 9; index++)
            if (!openCard[index].IsInteractable())
            {

                ulong diff = ((ulong)DateTime.Now.Ticks - cardOpen);
                ulong m = diff / TimeSpan.TicksPerMillisecond;
                float seconleft = (float)(msToWait - m) / 1000.0f;

                string t = "";

                t += ((int)seconleft / 3600).ToString() + "ч ";
                seconleft -= ((int)seconleft / 3600) * 3600;
                t += ((int)seconleft / 60).ToString("00") + "м ";
                t += ((int)seconleft % 60).ToString("00") + "с ";

                Timer.text = t;
                              
                Reload();
            
        }
    }


    public void Click(int index)
    {
        coins = PlayerPrefs.GetInt("coins");
        diamond = PlayerPrefs.GetInt("diamond");
        ind = index;
        cardOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("cartOpen", cardOpen.ToString());
        coinsText.text = coins.ToString();
        openCard[index].interactable = false;
        openCard[index].image.color = new Color32(255, 255, 0, 255);
        randomizer = (UnityEngine.Random.Range(0, 100));
        
        if (randomizer < 16)
        {
            openCard[index].image.sprite = img_diamond;
            int[] reward_diamond = {1, 2, 3, 4, 5};
            diamond += reward_diamond[new Random().Next(0, reward_diamond.Length)];
        }
        if (randomizer > 16)
        {
            openCard[index].image.sprite = img_coin;
            int[] reward_coin = { 10, 20, 50, 75, 100, 125, 150, 175, 200, 225, 250};
            coins += reward_coin[new Random().Next(0, reward_coin.Length)];

        }
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("diamond", diamond);
        for (int i = 0; i < 9; i++)
            {
                openCard[i].interactable = false;
            
            }

            Reload();
    }
    public bool Reload()
    {

        for (int i = 0;i < ind && i > ind; i++);
        {
            ulong diff = ((ulong)DateTime.Now.Ticks - cardOpen);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float seconleft = (float)(msToWait - m) / 1000.0f;


            if (seconleft < 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    openCard[i].interactable = true;
                }
                Timer.text = "Забрать награду";
                    return true;
                
            }
        }
        return false;
    }
}
