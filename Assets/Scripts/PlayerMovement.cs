using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    //I recommend 7 for the move speed, and 1.2 for the force damping
    private Rigidbody2D rb;
    private Vector2 forceToApply;
    private Vector2 moveInput;
    private Vector2 facingDirection;
    private float xScale;

    [SerializeField] private float dashAmount;
    [SerializeField] private KeyCode dashKey;
    [SerializeField] private float forceDamping;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        xScale = transform.localScale.x;
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        FaceDirection(moveInput);

        if (Input.GetKeyDown(dashKey))
        {
            forceToApply += facingDirection * dashAmount;
        }
    }

    void FixedUpdate()
    {
        Vector2 moveForce = moveInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce;
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Push"))
        {
            forceToApply += new Vector2(-20, 0);
            Destroy(collision.gameObject);
        }
    }
    
    private void FaceDirection(Vector2 moveInput)
    {
        if (moveInput == Vector2.zero)
        {
            return;
        }

        facingDirection = moveInput;
        Flip();
    }

    private void Flip()
    {
        transform.localScale = facingDirection.x < 0 ? new Vector3(-1 * xScale, transform.localScale.y) : new Vector3(xScale, transform.localScale.y);
    }
}