using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public Text scoreText;
    [SerializeField] public Text coinsText;
    [SerializeField] private int coins;



    public void Update()
    {
        scoreText.text = ((int)(0)).ToString();
        scoreText.text = ((int)(player.position.z / 2)).ToString();
        scoreText.text = ((int)(player.position.z / 2)).ToString();
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
    }
    
}
