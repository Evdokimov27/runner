using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clicker : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }
    public int coins;
    public Text coinsText;
    public void OnClickButton()
    {  
        coins = PlayerPrefs.GetInt("coins");
        coins += 1;
        coinsText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
