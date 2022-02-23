using System;
using UnityEngine.UI;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public float msToWait = 5000.0f;
    private Text Timer;
    private ulong lastOpen;
    public int day;
    public int coins;
    public int streak;
    public Text coinsText;
    [SerializeField] private Button rewardButton;
    [SerializeField] private Sprite claim;
    [SerializeField] private Sprite dotn_claim;
    [SerializeField] private Sprite now_claim;
    [SerializeField] private Transform rewards;



    void Start()
    {
        lastOpen = ulong.Parse(PlayerPrefs.GetString("lastOpen"));
        Timer = GetComponentInChildren<Text>();
        coins = PlayerPrefs.GetInt("coins");
        day = PlayerPrefs.GetInt("day");
        streak = day;
        if (!isReady())
        {
            rewardButton.interactable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = coins.ToString();
        if (day == 16)
        {
            day = 1;
        }
        if (!rewardButton.IsInteractable()) 
        {
            
            for (int n = 0; n < 16; n++)
            {
                if (n < streak-1)
                {
                    rewards.GetChild(n).GetComponent<Image>().sprite = claim;
                    rewards.GetChild(n).GetComponent<Image>().color = new Color32(16, 255, 0, 100);
                }


            }
            if (isReady()) 
            {
                Timer.text = "Забрать награду";
                for (int i = 0; i < 16; i++)
                {
                    if (i == day - 1)
                    {
                        rewards.GetChild(i).GetComponent<Image>().sprite = now_claim;
                    }
                }
                rewardButton.interactable = true;
               

                return;
            }
             ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
             ulong m = diff / TimeSpan.TicksPerMillisecond;
             float seconleft = (float)(msToWait - m) / 1000.0f;

             string t = "";

             t += ((int)seconleft / 3600).ToString() + "ч ";
             seconleft -= ((int)seconleft / 3600) * 3600;
             t += ((int)seconleft / 60).ToString("00") + "м ";
             t += ((int)seconleft % 60).ToString("00") + "с ";

             Timer.text = t;
        }
    }
    public void Rewards()
    {

        if (day == 1)
        {
            coins += 150;
            coinsText.text = coins.ToString();
        }
        if (day == 2)
        {
            coins += 200;
            coinsText.text = coins.ToString();

        }
        if (day == 3)
        {
            coins += 500;
            coinsText.text = coins.ToString();

        }
        if (day == 4)
        {
            coins += 750;
            coinsText.text = coins.ToString();

        }
        if (day == 5)
        {
            coins += 1000;
            coinsText.text = coins.ToString();
        }
        if (day == 6)
        {
            coins += 1250;
            coinsText.text = coins.ToString();
        }
        if (day == 7)
        {
            coins += 1500;
            coinsText.text = coins.ToString();
        }
        if (day == 8)
        {
            coins += 1750;
            coinsText.text = coins.ToString();
        }
        if (day == 9)
        {
            coins += 2000;
            coinsText.text = coins.ToString();
        }
        if (day == 10)
        {
            coins += 2500;
            coinsText.text = coins.ToString();
        }
        if (day == 11)
        {
            coins += 3000;
            coinsText.text = coins.ToString();
        }
        if (day == 12)
        {
            coins += 4000;
            coinsText.text = coins.ToString();
        }
        if (day == 13)
        {
            coins += 5000;
            coinsText.text = coins.ToString();
        }
        if (day == 14)
        {
            coins += 7500;
            coinsText.text = coins.ToString();
        }
        if (day == 15)
        {
            coins += 10000;
            coinsText.text = coins.ToString();
            if (day == 16)
            {
                day = 1;
               
            }
        }
    }
    public void Click() {
        lastOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
        coinsText.text = coins.ToString();
        rewardButton.interactable = false;
        day += 1;
        streak = day;
        PlayerPrefs.SetInt("day", day);
        Rewards();
    }

    
    private bool isReady() {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float seconleft = (float)(msToWait - m) / 1000.0f;


        if (seconleft < 0)
        {
            Timer.text = "Забрать награду";
            return true;
        }
       
        return false;
    }

    
}
