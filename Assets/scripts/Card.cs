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
    public Text coinsText;
    public int coins;
    public int diamond;
    private ulong cardOpen = ((ulong)1);
    [SerializeField] private Sprite img_coin;
    [SerializeField] private Sprite img_diamond;
    [SerializeField] private Sprite background; 
     [SerializeField] public int randomizer;


    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
    }

    // Update is called once per frame
    void Update()
    { 
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
        }
        if (randomizer > 16)
        {
            openCard[index].image.sprite = img_coin;
            int[] reward_coin = { 10, 20, 50, 100, 250, 500};
            coins += reward_coin[new Random().Next(1, reward_coin.Length)];

        }
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
