using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyback : MonoBehaviour
{
    [SerializeField] private int diamond;
    [SerializeField] public int priceBuyback;
    [SerializeField] public Text txt_priceBuyback;
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        diamond = PlayerPrefs.GetInt("diamond");
    }

    // Update is called once per frame
    void Update()
    {
        diamond = PlayerPrefs.GetInt("diamond");
        txt_priceBuyback.text = priceBuyback.ToString();
    }
    public void CheckDiamond()
    {
    if (diamond >= priceBuyback)
        {
            Buyback();
        }
    else
        {
            return;
        }

    }


    public void Buyback()
    {
            diamond = diamond - priceBuyback;
            PlayerPrefs.SetInt("diamond", diamond);
            StartCoroutine(Player.GetComponent<PlayerController>().Reincornation());
    }
}
