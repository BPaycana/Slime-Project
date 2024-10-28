using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public float extraSpace;

    // Figures out the screen boundaries in the start.
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Make sure that the view and the player is clampped to the boundaries during play
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth - extraSpace, screenBounds.x - objectWidth + extraSpace);
        transform.position = viewPos;
    }
}