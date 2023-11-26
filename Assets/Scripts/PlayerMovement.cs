using System;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    //I recommend 7 for the move speed, and 1.2 for the force damping
    private Rigidbody2D rb;
    private Vector2 forceToApply;
    private Vector2 moveInput;
    private Vector2 facingDirection;
    private float xScale;
    private float initialDashCooldown;
    private bool canDash;
    private bool isSlippery;

    [SerializeField] private float dashAmount;
    [SerializeField] private KeyCode dashKey;
    [SerializeField] private float forceDamping;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashCooldown;

    private void Awake()
    {
        initialDashCooldown = dashCooldown;
        dashCooldown = 0;
        rb = GetComponent<Rigidbody2D>();
        xScale = transform.localScale.x;
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChange;
    }

    private static void OnStateChange(GameState state)
    {
        //lock player movement depending on the state etc.
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        FaceDirection(moveInput);
        dashCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(dashKey) && dashCooldown <= 0 && canDash)
        {
            AudioManager.Instance.PlaySound("DashSound");
            forceToApply += facingDirection * dashAmount;
            dashCooldown = initialDashCooldown;
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

    public void ActivateDash()
    {
        canDash = true;
    }

    public void ActivateSlippery()
    {
        isSlippery = true;
    }

    private void Flip()
    {
        transform.localScale = facingDirection.x < 0 ? new Vector3(-1 * xScale, transform.localScale.y) : new Vector3(xScale, transform.localScale.y);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStateChanged -= OnStateChange;
    }
}