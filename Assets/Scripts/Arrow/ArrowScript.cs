using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.linearVelocity = Direction * Speed;
        Rigidbody2D.gravityScale = 0.2f;
    }

    void Update()
    {


    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.collider.CompareTag("Ground"))
    {
        Rigidbody2D.linearVelocity = Vector2.zero;
        Rigidbody2D.bodyType = RigidbodyType2D.Kinematic; 
        Rigidbody2D.freezeRotation = true;
        Destroy(this); 
    }
}


}
