using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    
    [SerializeField] private Transform Tilemap;
    [SerializeField] private Transform Grid;

    // private int y = 0;
    // private float currentTime = 0f;
    // private float startingTime = 1f;
    
    void Start()
    {
        StartCoroutine(SpawnLevel());
        // currentTime = startingTime;
    }

    void Update()
    {
        // currentTime -= 1 * Time.deltaTime;

        // if (currentTime <= 0)
        // {
        //     y += 10;
        //     Instantiate(Tilemap, new Vector3(0, y), Quaternion.identity, Grid);
        //     currentTime = startingTime;
        // }
    }

    IEnumerator SpawnLevel()
    {
        int y = 0;

        while(true)
        {
            yield return new WaitForSeconds(1f);
            y += 10;
            Instantiate(Tilemap, new Vector3(0, y), Quaternion.identity, Grid);
        }
    }
}
