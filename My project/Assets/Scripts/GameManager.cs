using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    Camera cam;

    public Controller controller;
    [SerializeField] float pushForce = 4f;
    public Trajectory trajectory;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    void Start()
    {
        cam = Camera.main;
        controller.DeactivateRb();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown (0) && controller.rb.velocity.magnitude == 0)
        {
            isDragging = true;
            OnDragStart();
        }

        if (Input.GetMouseButtonUp (0) && controller.rb.velocity.magnitude == 0)
        {
            isDragging = false;
            OnDragEnd();
        }

        if (isDragging && controller.rb.velocity.magnitude == 0)
        {
            OnDrag();
        }
    }

    void OnDragStart()
    {
        controller.DeactivateRb();
        startPoint = cam.ScreenToWorldPoint (Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
        distance = Vector2.Distance (startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        trajectory.UpdateDots(controller.pos, force);
    }

    void OnDragEnd()
    {
        controller.ActivateRb();
        controller.Push (force);

        trajectory.Hide();
    }
}
