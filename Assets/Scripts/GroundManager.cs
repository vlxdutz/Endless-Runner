using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundTilePrefab;
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;

    public int numberOfTiles = 4;

    public float tileLenght = 10f;

    private Transform playerTransform;

    private List<GameObject> groundTiles = new List<GameObject>();

    private List<GameObject> coins = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < numberOfTiles; i++) {
            SpawnGroundTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - groundTiles[0].transform.position.z >= tileLenght) {
            DestroyGroundTile();
            SpawnGroundTile();
        }
    }

    //Generam un Tile
    void SpawnGroundTile() {
        Vector3 spawnPosition = Vector3.zero;

        if(groundTiles.Count > 0) {
            spawnPosition = groundTiles[groundTiles.Count - 1].transform.position + Vector3.forward * tileLenght;
        } else {
            spawnPosition = Vector3.zero + Vector3.forward * tileLenght;
        }

        GameObject newTile = Instantiate(groundTilePrefab, spawnPosition, Quaternion.identity);

        groundTiles.Add(newTile);

        List<int> availableSpawn = new List<int>() {-3, 0, 3};
        int randomIndex = Random.Range(0, availableSpawn.Count);
        int obstacleX = availableSpawn[randomIndex];
        
        availableSpawn.RemoveAt(randomIndex);
        int coinX = availableSpawn[Random.Range(0, availableSpawn.Count)];

        Vector3 obstacleSpawnPosition = new Vector3(obstacleX, 0.5f, 0f);
        GameObject newObstacle = Instantiate(obstaclePrefab, obstacleSpawnPosition, Quaternion.identity);

        Vector3 coinSpawnPosition = new Vector3(coinX, 0.5f, 0f);
        GameObject newCoin = Instantiate(coinPrefab, coinSpawnPosition, Quaternion.identity);

        newObstacle.transform.SetParent(newTile.transform, false);
        newCoin.transform.SetParent(newTile.transform, false);
    }

    void DestroyGroundTile() {
        GameObject tileToDestroy = groundTiles[0];

        groundTiles.RemoveAt(0);

        Destroy(tileToDestroy);
    }
}
