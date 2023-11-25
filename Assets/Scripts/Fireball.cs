using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    public float min = 2f;
    public float max = 3f;
    // Use this for initialization
    void Start()
    {

        min = transform.position.x - min;
        max = transform.position.x + max;

    }
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

    }
}
