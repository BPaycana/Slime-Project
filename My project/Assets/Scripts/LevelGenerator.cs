using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform Grid;
    public Transform[] levels;

    public float spawnTime = 2f;
    private int randomLevel = 0;
    void Start()
    {
        Instantiate(levels[randomLevel], new Vector3(0, 0), Quaternion.identity, Grid);
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

            if (randomLevel >= levels.Length / 2)
            {
                randomLevel = Random.Range(0, levels.Length / 2);
            }

            else
            {
                randomLevel = Random.Range(levels.Length / 2, levels.Length);
            } 
            Debug.Log(randomLevel);
            Instantiate(levels[randomLevel], new Vector3(0, y), Quaternion.identity, Grid);
        }
    }
}
