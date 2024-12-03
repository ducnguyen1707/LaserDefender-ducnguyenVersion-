 using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
     [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 rawInput;
    Vector2 minBound;
    Vector2 maxBound;
    Shooter shooter;

    void Awake()
    {
        shooter= GetComponent<Shooter>(); 
    }
    void Start()
    {
        InitBounds();
    }
    void Update()
    {
       Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1f, 1f));
    }
    void Move(){
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x -paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingTop, maxBound.y - paddingBottom);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput =value.Get<Vector2>();
        // Debug.Log(rawInput);
    }

    void OnFire(InputValue value){
        if(shooter!=null){
            shooter.isFiring = value.isPressed;
        }
    }
}
