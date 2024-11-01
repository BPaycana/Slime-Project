using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeathBox : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    
    public float speed;
    public float timer;
    public float speedIncrease;
    public float speedCap;
    public Controller player;

    Coroutine lastRoutine = null;

    void Start()
    {
       lastRoutine = StartCoroutine(SpeedUp());
    }

    //Updates the deathbox's position.
    void Update()
    {
        var step = (speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, player.transform.position.y, player.transform.position.z), step);

        if (speed >= speedCap)
        {
            StopCoroutine(lastRoutine);
        }
    }

    //Lets it speed up over time.
    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);

            if (speed >= speedCap)
            {
                StopCoroutine(lastRoutine);
            }

            speed += speedIncrease;

            Debug.Log(speed);
        }
        
    }

    //Code that plays on collision.
    private void OnCollisionEnter2D(Collision2D collision)
    {   

        //Checks to see the other objects tag and hit position and deletes it if its a platform.
        if (collision.gameObject.CompareTag("Platform"))
        {
            Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
            Vector3 hitPosition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }

        //Checks to see if its a player and plays the game over screen if it is.
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            UIManager.GameOver();
            Debug.Log("You Are Dead!");
        }
        
    }
}
