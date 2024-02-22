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

    public LayerMask solidObjectsLayer;

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
    public void HandleUpdate()
    {
        //if (!isMoving)
        //{
        //    input.x = Input.GetAxisRaw("Horizontal");
        //}
        Vector2 veloX = Vector2.zero, veloY = Vector2.zero;

        if (controller.IsUp())
        {
            veloY = Vector2.up;
        }

        if (controller.IsDown())
        {
            veloY = Vector2.down;
        }

        if (controller.IsRight())
        {
            veloX = Vector2.right;
        }
        
        if (controller.IsLeft())
        {
            veloX = Vector2.left;

        }
        //spdX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        //spdY = Input.GetAxisRaw("Vertical") * moveSpeed;
        //rb.velocity = new Vector2(spdX, spdY);

        Vector2 velo = veloX + veloY;
        

        var targetPos = transform.position;
        if (velo.x > 0)
        {
            targetPos.x += 0.2f;
        } else if (velo.x == 0)
        {

        }
        else
        {
            targetPos.x += -0.2f;
        }

        if (velo.y > 0)
        {
            targetPos.y += 0.2f;
        }
        else if (velo.y == 0)
        {

        }
        else
        {
            targetPos.y += -0.2f;
        }

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
            animator.SetFloat("moveY", velo.y);
            animator.SetFloat("moveX", velo.x);
            animator.SetBool("isMoving", true);
        }

        if (IsWalkable(targetPos))
        {
            rb.velocity = velo * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
}
