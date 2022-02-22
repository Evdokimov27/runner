using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject GameMenu;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Player;
    [SerializeField] private Text coinsText;
    [SerializeField] private int coins;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void Play()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString(); 
        GameMenu.SetActive(false);
        Player.SetActive(true);
        UI.SetActive(true);
    }
    public void Shop()
    {
        GameMenu.SetActive(true);
        UI.SetActive(false);
        


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
