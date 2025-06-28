using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker_Movement : MonoBehaviour
{
    private Rigidbody2D RigidBody2D;
    private float Horizontal;
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        RigidBody2D.linearVelocity = new Vector2(Horizontal, RigidBody2D.linearVelocity.y);
    }
}
