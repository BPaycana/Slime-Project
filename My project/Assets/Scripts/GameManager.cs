using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool canJump = false;

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
        if (Input.GetMouseButtonDown (0) && canJump == true)
        {
            isDragging = true;
            OnDragStart();
        }

        if (Input.GetMouseButtonUp (0)  && canJump == true)
        {
            isDragging = false;
            OnDragEnd();

            canJump = false;


        }

        if (isDragging)
        {
            OnDrag();
        }

        if (controller.rb.velocity.magnitude == 0 && Input.GetMouseButton (0) == false)
        {
            canJump = true;
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
        controller.animator.SetBool("isCharging", true);

        endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
        distance = Vector2.Distance (startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = Vector2.ClampMagnitude((direction * distance * pushForce * 2), 40);

        trajectory.UpdateDots(controller.pos, force);
    }

    void OnDragEnd()
    {
        controller.animator.SetBool("isCharging", false);

        controller.ActivateRb();
        controller.Push (force);

        trajectory.Hide();
    }
}
