using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker_Movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private bool Grounded;
    private Rigidbody2D RigidBody2D;
    private float Horizontal;
    
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W)&&Grounded==true)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        RigidBody2D.linearVelocity = new Vector2(Horizontal, RigidBody2D.linearVelocity.y);
    }

    private void Jump()
    {
        RigidBody2D.AddForce(Vector2.up * JumpForce);
    }
}
