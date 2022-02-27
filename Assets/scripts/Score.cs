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
    [SerializeField] public int score;

    [SerializeField] public Text recordText;
    private int recordScore;

    private void Start()
    {
        recordScore = PlayerPrefs.GetInt("recordScore");
    }
    public void Update()
    {

        score = ((int)(player.position.z / 2));
        scoreText.text = score.ToString();
        coins = PlayerPrefs.GetInt("coins");
        diamond = PlayerPrefs.GetInt("diamond");
        coinsText.text = coins.ToString();
        diamondText.text = diamond.ToString();
;
    }
    public void Record()
    {
        if (score > recordScore)
        {
            recordScore = score;
            PlayerPrefs.SetInt("recordScore", recordScore);
            recordText.text = "Новый рекорд: " + recordScore.ToString();
        }
        else
        {
            recordText.text = "Рекорд: " + recordScore.ToString();
        }
    }

}
