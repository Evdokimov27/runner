using UnityEngine;
using System.Collections;

public class Skins : MonoBehaviour
{
    public GameObject skin1;
    public Avatar _skin1;
    public GameObject skin2;
    public Avatar _skin2;
    public GameObject Player;

    GameObject model;
    // Use this for initialization
    private void Awake()
    {

        void Start()
        {

          


            model.transform.SetParent(Player.transform);
            model.transform.localPosition = new Vector3(0, 0, 0);
        }


        // Update is called once per frame
        void Update()
        {

        }

    }
}