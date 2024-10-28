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
        //Instatiates the first static level
        Instantiate(levels[randomLevel], new Vector3(0, 0), Quaternion.identity, Grid);

        //Begins the coroutine to start spawning levels
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
            y += 12;


            //Alternates between even and odd levels to make sure the player isn't stuck.
            if (randomLevel >= levels.Length / 2)
            {
                randomLevel = Random.Range(0, levels.Length / 2);
            }

            else
            {
                randomLevel = Random.Range(levels.Length / 2, levels.Length);
            } 
            Instantiate(levels[randomLevel], new Vector3(0, y), Quaternion.identity, Grid);
        }
    }
}
