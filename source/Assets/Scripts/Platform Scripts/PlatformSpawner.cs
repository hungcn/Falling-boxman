using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platformSpawnerTimer = 1.5f;
    private float currentPlatformSpawnerTimer;

    private int platformSpawnCount;
    
    public float minX = -2f, maxX = 2f;

    // Start is called before the first frame update
    void Start()
    {
        currentPlatformSpawnerTimer = platformSpawnerTimer;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        currentPlatformSpawnerTimer += Time.deltaTime;
        
        if (currentPlatformSpawnerTimer >= platformSpawnerTimer)
        {
            platformSpawnCount++;

            Vector3 tmp = transform.position;
            tmp.x += Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (platformSpawnCount < 2)
                newPlatform = Instantiate(platformPrefab, tmp, Quaternion.identity);
            else if (platformSpawnCount < 4) {
                if (Random.Range(0,2) > 0)
                    newPlatform = Instantiate(platformPrefab, tmp, Quaternion.identity);
                else {
                    newPlatform = Instantiate(
                        movingPlatforms[Random.Range(0, movingPlatforms.Length)],
                        tmp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4) {
                if (Random.Range(0,2) > 0)
                    newPlatform = Instantiate(platformPrefab, tmp, Quaternion.identity);
                else 
                    newPlatform = Instantiate(breakablePlatform, tmp, Quaternion.identity);
            }
            else if (platformSpawnCount == 5) {
                if (Random.Range(0,2) > 0)
                    newPlatform = Instantiate(platformPrefab, tmp, Quaternion.identity);
                else 
                    newPlatform = Instantiate(spikePlatformPrefab, tmp, Quaternion.identity);
             
                platformSpawnCount = 0;
            }

            if (newPlatform)
                newPlatform.transform.parent = transform;
            currentPlatformSpawnerTimer = 0f;
        }
    }

}

