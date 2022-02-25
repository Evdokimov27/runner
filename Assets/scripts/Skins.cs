using UnityEngine;
using System.Collections;

public class Skins : MonoBehaviour
{
    Animator avatar;
    public Avatar[] skins;
    [SerializeField] private GameObject Player;

    GameObject model;
    // Use this for initialization
    private void Awake()
    {
        int skin = PlayerPrefs.GetInt("skin");
        for (int x = 0; x < skins.Length; x++)
        {
            if (x == skin)
            {
                avatar = GetComponent<Animator>();
                avatar.avatar = skins[skin] as Avatar;
            }
        }
       

        // Update is called once per frame



    }
}