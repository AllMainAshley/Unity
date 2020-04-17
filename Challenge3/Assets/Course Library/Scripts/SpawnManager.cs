using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacalPrefab;
    private Vector3 SpawnPos = new Vector3(30, 0, 0);
    private float StartDelay = 2;
    private float spawnInterval = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObstacle", StartDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle()
    {
        Instantiate(obstacalPrefab, SpawnPos, obstacalPrefab.transform.rotation);
    }
}
