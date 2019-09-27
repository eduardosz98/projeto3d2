using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform tile;

    public Transform obstacle;
    public Transform capsuleSlow;
    public Transform ObstacleYellow;

    public Vector3 startPoint = new Vector3(0,0,-5);

    public int initSpawnNum = 10;

    public int initNoObstacles = 4;

    private Vector3 nextTileLocation;
    private Quaternion nextTileRotation;

    public float timer;

    void Start()
    {
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i) {
            SpawnNextTile( i>= initNoObstacles);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void SpawnNextTile(bool spawnObstacle = true) {

        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);
        var nextTile = newTile.Find("Spawn Point");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;        

        if (!spawnObstacle)
            return;

        var obstacleSpawnPoints = new List<GameObject>();
        var capsuleSpawnPoints = new List<GameObject>();
        var yellowSpawnPoints = new List<GameObject>();

        foreach (Transform child in newTile)
        {
            if (child.CompareTag("ObstacleSpawn"))
            {
                obstacleSpawnPoints.Add(child.gameObject);
                PlayerBehaviour.rollIncrease+=0.01f;
            }
            if (child.CompareTag("CapsuleSpawn"))
            {
                capsuleSpawnPoints.Add(child.gameObject);
            }
            if (child.CompareTag("YellowSpawn"))
            {
                yellowSpawnPoints.Add(child.gameObject);
            }

        }

        if (yellowSpawnPoints.Count > 0)
        {
            var YellowspawnPoint = yellowSpawnPoints[Random.Range(0, yellowSpawnPoints.Count)];

            var spawnPos = YellowspawnPoint.transform.position;

            var newObstacleYellow = Instantiate(ObstacleYellow, spawnPos, Quaternion.identity);

            newObstacleYellow.SetParent(YellowspawnPoint.transform);                      

        }

        if (obstacleSpawnPoints.Count > 0)
        {
            var spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count)];

            var spawnPos = spawnPoint.transform.position;

            var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

            newObstacle.SetParent(spawnPoint.transform);

        }

        if (timer > 9.2f) {
            if(capsuleSpawnPoints.Count > 0)
            {
                var capsSpawPoint = capsuleSpawnPoints[Random.Range(0, capsuleSpawnPoints.Count)];
                var spawnPos = capsSpawPoint.transform.position;

                var newCapsule = Instantiate(capsuleSlow, spawnPos, Quaternion.identity);
                newCapsule.SetParent(capsSpawPoint.transform);
            }
        }

    }
}
