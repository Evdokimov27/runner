using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField] Score score;
    public GameObject[] tilePrefabs;
    public GameObject[] eazyTilePrefabs;
    [SerializeField] private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 150;
    private float tileLength = 150;
    [SerializeField] private int level = 0;


    [SerializeField] private Transform player;
    [SerializeField] private int startTiles = 2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startTiles; i++)
        {
            EazyTile(Random.Range(0, eazyTilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score.scoreText.text == "200")
            level = 1;
        if (score.scoreText.text == "350")
            level = 2;
        if (player.position.z - 253 > spawnPos - (startTiles * tileLength))
        {
            if (level == 1)
            {
                EazyTile(Random.Range(0, eazyTilePrefabs.Length));
                DeleteTile();
            }
            if (level == 2)
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
                DeleteTile();
            }
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void EazyTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(eazyTilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}