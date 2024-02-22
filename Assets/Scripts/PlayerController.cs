using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    float spdX, spdY;
    Rigidbody2D rb;

    [SerializeField]
    private ControllerControl controller;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //if (!isMoving)
        //{
        //    input.x = Input.GetAxisRaw("Horizontal");
        //}
        Vector2 veloX = Vector2.zero, veloY = Vector2.zero;

        if (controller.IsUp())
        {
            veloY = Vector2.up;
            animator.SetFloat("moveY", 1f);
            animator.SetFloat("moveX", 0f);
        }

        if (controller.IsDown())
        {
            veloY = Vector2.down;
            animator.SetFloat("moveY", -1f);
            animator.SetFloat("moveX", 0f);
        }

        if (controller.IsRight())
        {
            veloX = Vector2.right;
            animator.SetFloat("moveX", 1f);
            animator.SetFloat("moveY", 0f);
        }
        
        if (controller.IsLeft())
        {
            veloX = Vector2.left;
            animator.SetFloat("moveX", -1f);
            animator.SetFloat("moveY", 0f);
        }
        //spdX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        //spdY = Input.GetAxisRaw("Vertical") * moveSpeed;
        //rb.velocity = new Vector2(spdX, spdY);
        Vector2 velo = veloX + veloY; 
        if (velo.x != 0 & velo.y != 0)
        {
            velo = velo / 1.5f;
            
        }
        
        if (velo == Vector2.zero)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        rb.velocity = velo * moveSpeed;
    }
}
