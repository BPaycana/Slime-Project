using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FizzBuzz : MonoBehaviour
{
    
    void Start()
    {
        for (int i = 1; i < 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Debug.Log("FizzBuzz");
            }

            else if (i % 5 == 0)
            {
                Debug.Log("Buzz");
            }

            else if (i % 3 == 0)
            {
                Debug.Log("Fizz");
            }

            else
            {
                Debug.Log(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
