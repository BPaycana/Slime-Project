using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int height;
    private int score = 0;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        height = Mathf.FloorToInt(gameManager.controller.transform.position.y);

        if (height > score)
        {
            score = height;
        }

        scoreText.text = "Height: " + score + "m";
    }
}
