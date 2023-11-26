using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public MovementType movementType = MovementType.LINEAR;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (movementType)
        {
            case MovementType.LINEAR:
                break;
            case MovementType.WAVE:
                var timeSin = Mathf.Sin(Time.deltaTime) * 30;
                rigidbody2D.AddForce(new Vector2(timeSin, timeSin));
                break;
            case MovementType.CURVE:
                break;
            case MovementType.STATIONARY:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    void FixedUpdate()
    {
        
    }
    
    public void Launch(Vector2 direction, float force)
    {
        Destroy(gameObject, 15);
        switch (movementType)
        {
            case MovementType.LINEAR:
                rigidbody2D.AddForce(direction * force);
                break;
            case MovementType.WAVE:
                break;
            case MovementType.CURVE:
                rigidbody2D.gravityScale = Random.Range(0, 1) == 0 ? force*Time.deltaTime*0.1f : -force*Time.deltaTime*0.1f;
                if (direction == Vector2.up || direction == Vector2.down)
                {
                    direction = Random.Range(0,1) == 0 ? Vector2.left : Vector2.right;
                }
                rigidbody2D.AddForce(direction * force);
                break;
            case MovementType.STATIONARY:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum MovementType
{
    LINEAR,
    WAVE,
    CURVE,
    STATIONARY
}
