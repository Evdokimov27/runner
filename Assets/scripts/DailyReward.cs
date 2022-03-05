using System;
using UnityEngine.UI;
using UnityEngine;

public class DailyReward : MonoBehaviour
{
    public float msToWait = 0f;
    public  Text Timer;
    private ulong lastOpen = ((ulong)1);
    public int day;
    public int coins;
    public int diamond;
    public int streak;
    public Text coinsText;
    [SerializeField] private Button rewardButton;
    [SerializeField] private Sprite claim;
    [SerializeField] private Sprite dotn_claim;
    [SerializeField] private Sprite now_claim;
    [SerializeField] private Transform rewards;
    [SerializeField] private Transform skin_reward;
    [SerializeField] private Text diamondText;



    void Start()
    {
        PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
        day = 0;
        coinsText.text = coins.ToString();
        diamondText.text = diamond.ToString();
        day = PlayerPrefs.GetInt("day");
        streak = day;
        isReady();
    }

    // Update is called once per frame
    void Update()
    {
        lastOpen = ulong.Parse(PlayerPrefs.GetString("lastOpen"));
        coins = PlayerPrefs.GetInt("coins");
        diamond = PlayerPrefs.GetInt("diamond");
        coinsText.text = coins.ToString();
        diamondText.text = diamond.ToString();


        if (!rewardButton.IsInteractable())
        {


            if (isReady())
            {
                Timer.text = "Забрать награду";

                rewardButton.interactable = true;
                UI();


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
            UI();
        }
    }
    public void UI()
    {
        coinsText.text = coins.ToString();
        diamondText.text = diamond.ToString();
        day = PlayerPrefs.GetInt("day");
        for (int n = 0; n < 15; n++)
        {
            if (n < day)
            {
                rewards.GetChild(n).GetComponent<Image>().sprite = claim;
                rewards.GetChild(n).GetComponent<Image>().color = new Color32(16, 255, 0, 255);
            }

            for (int i = 0; i < 15; i++)
            {
                if (i == day)
                {
                    rewards.GetChild(i).GetComponent<Image>().sprite = now_claim;
                    rewards.GetChild(i).GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                }
            }

        }
        if (day == 1)
        {
            isReady();
            rewards.GetChild(0).GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }

        else if (day == 15)
        {

            for (int f = 1; f < 15; f++)
            {
                if (f < 15)
                {
                    rewards.GetChild(f).GetComponent<Image>().sprite = dotn_claim;
                    rewards.GetChild(f).GetComponent<Image>().color = new Color32(16, 255, 0, 100);
                    rewards.GetChild(0).GetComponent<Image>().sprite = now_claim;
                    rewards.GetChild(0).GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                }

                day = 1;
            }
        }

    }

      // Награды перенесены в SkinShop для возможности получения скинов за ежедневные заходы

    public void Click() {
        lastOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
        coinsText.text = coins.ToString();
        rewardButton.interactable = false;
        day += 1;
        PlayerPrefs.SetInt("day", day);
       
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
