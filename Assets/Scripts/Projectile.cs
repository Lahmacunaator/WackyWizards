using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public MovementType movementType = MovementType.LINEAR;

    private Vector2 forward, spawnPos;
    private float amp;
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
        if (movementType == MovementType.SINE)
        {
            transform.position = Vector3.Lerp(transform.parent.position,
                new Vector3(spawnPos.x, spawnPos.y - 10),
                Mathf.Sin(Time.time * amp) * 0.5f + 0.5f);
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
            case MovementType.SINE:
                forward = direction;
                amp = force;
                break;
            case MovementType.CURVE:
                
                if (direction == Vector2.up || direction == Vector2.down)
                {
                    direction = Random.Range(0,1) == 0 ? Vector2.left : Vector2.right;
                    rigidbody2D.gravityScale = direction==Vector2.down ? -force*Time.deltaTime*0.1f : force*Time.deltaTime*0.1f;
                }
                else
                {
                    rigidbody2D.gravityScale = Random.Range(0, 1) == 0 ? force*Time.deltaTime*0.1f : -force*Time.deltaTime*0.1f;
                }
                rigidbody2D.AddForce(direction * force);
                break;
            case MovementType.STATIONARY:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<Health>().TakeDamage();
            Destroy(gameObject);
        }
    }
}


public enum MovementType
{
    LINEAR,
    SINE,
    CURVE,
    STATIONARY
}
