using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{

    private int back = 0;

    [SerializeField] private InterstitialAd Ads;

    public void RestartLevel()
    {
        back = Random.Range(0, 5);
        Debug.Log(back);
        if (back == 0)
        {
            Ads.ShowAd();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
