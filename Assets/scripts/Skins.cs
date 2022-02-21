using UnityEngine;
using System.Collections;

public class Skins : MonoBehaviour
{
    Animator avatar;
    public GameObject _skin1;
    public GameObject _skin2;
    public Avatar skin1;
    public Avatar skin2;
    [SerializeField] public GameObject Player;

    GameObject model;
    // Use this for initialization
    private void Awake()
    {
        int skin = PlayerPrefs.GetInt("skin");
        if (skin == 0)
        {
            avatar = GetComponent<Animator>();
            avatar.avatar = skin1 as Avatar;
        }
        if (skin == 1)
        {
            avatar = GetComponent<Animator>();
            avatar.avatar = skin2 as Avatar;
        }

        // Update is called once per frame



    }
}