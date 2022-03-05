using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public Text scoreText;
    [SerializeField] public Text coinsText;
    [SerializeField] public Text diamondText;
    [SerializeField] private int coins;
    [SerializeField] private int diamond;
    [SerializeField] public int int_score;



    public void Update()
    {
        int_score = (int)player.position.z/2;
        scoreText.text = ((int)(0)).ToString();
        scoreText.text = ((int)(player.position.z / 2)).ToString();

        coins = PlayerPrefs.GetInt("coins");
        diamond = PlayerPrefs.GetInt("diamond");
        coinsText.text = coins.ToString();
        diamondText.text = diamond.ToString();
    }
    
}
