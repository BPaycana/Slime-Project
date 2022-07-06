using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeathBox : MonoBehaviour
{
    public float speed = 2.0f;
    public float timer = 5.0f;
    public Controller player;

    void Start()
    {
        StartCoroutine(SpeedUp());
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, player.transform.position.y, player.transform.position.z), step);
    }

    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            speed += 2.0f;
            Debug.Log(speed);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        
        Debug.Log("You Are Dead!");
    }
}
