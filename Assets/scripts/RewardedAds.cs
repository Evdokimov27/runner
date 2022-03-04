using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAds S;
    [SerializeField] Button[] rewardButtons;
    [SerializeField] private Button respawn;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] private string _iOSAdUnitId = "Rewarded_iOS"; 
    private string _adUnitId;
    int coins;
    int diamond;
    [SerializeField] GameObject time;
    public static int clk_button;


    private void Awake()
    {
        diamond = PlayerPrefs.GetInt("diamond");
        coins = PlayerPrefs.GetInt("coins");
        S = this;

        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
    public void Index(int index)
    {
       clk_button = index;
       PlayerPrefs.GetString("clk_button", clk_button.ToString());
    }
        
    

    public void ShowAd()
    {

        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }


    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Реклама просмотренна");
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
                {
            Debug.Log("Button: " + clk_button);
                if (clk_button == 9)
                {
                Time.timeScale = 1;
                respawn.interactable = false;
                StartCoroutine(Player.GetComponent<PlayerController>().Reincornation());
                Player.GetComponent<PlayerController>().ReincPos();
            }
                if (clk_button == 0)
                {

                }     
                // Load another ad:
                Advertisement.Load(_adUnitId, this);
            }
        }
    

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
}
