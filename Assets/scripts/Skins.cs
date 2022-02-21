using UnityEngine;
using System.Collections;

public class Skins : MonoBehaviour
{
    Animator avatar;
    public Avatar skin1;
    public Avatar skin2;
    public Avatar skin3;
    public Avatar skin4;
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
        if (skin == 2)
        {
            avatar = GetComponent<Animator>();
            avatar.avatar = skin3 as Avatar;
        }
        if (skin == 3)
        {
            avatar = GetComponent<Animator>();
            avatar.avatar = skin4 as Avatar;
        }

        // Update is called once per frame



    }
}