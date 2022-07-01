using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform Level1;
    [SerializeField] private Transform Level2;
    [SerializeField] private Transform Grid;
    public Transform[] levels;

    public float spawnTime = 2f;
    
    void Start()
    {
        StartCoroutine(SpawnLevel());
        // currentTime = startingTime;
    }

    void Update()
    {

    }

    IEnumerator SpawnLevel()
    {
        int y = 0;

        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            y += 10;
            int randomLevel = Random.Range(0, levels.Length);
            Instantiate(levels[randomLevel], new Vector3(0, y), Quaternion.identity, Grid);
        }
    }
}
