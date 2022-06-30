using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public float speed = 1.0f;
    public Controller player;

    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, player.transform.position.y, player.transform.position.z), step);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You Are Dead!");
    }
}
