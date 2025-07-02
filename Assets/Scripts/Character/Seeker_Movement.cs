using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker_Movement : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public float Speed;
    public float JumpForce;
    private bool Grounded;
    private Rigidbody2D RigidBody2D;
    private Animator Animator;
    private float Horizontal;

    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        RigidBody2D.freezeRotation = true;
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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

    private void Shoot()
    {
        //Detector de dirección
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        //Utiliza el prefab indicado y lo duplica en una parte del mundo, sin rotación
        GameObject arrow = Instantiate(ArrowPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        arrow.GetComponent<ArrowScript>().SetDirection(direction);
    }
}
