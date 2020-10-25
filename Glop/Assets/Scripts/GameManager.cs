﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }
    #endregion

    Camera cam;

    public Glop glop;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;
    bool ifDragged = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    void Start()
    {
        cam = Camera.main;
        glop.DeactivateRb();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }

        if (isDragging)
        {
            OnDrag();
        }
    }

    //Drag
    
    void OnDragStart()
    {
            
            glop.DeactivateRb();
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

            trajectory.Show();
        
    }
    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        //just for debug
        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(glop.pos, force);
    }
    void OnDragEnd()
    {
        //push glop
        glop.ActivateRb();

        glop.Push(force);

        trajectory.Hide();
    }
}