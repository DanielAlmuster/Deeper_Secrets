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
    private Queue<GameObject> arrowList = new Queue<GameObject>();
    private int maxArrows = 3;

    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        RigidBody2D.freezeRotation = true;
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-0.25f, 0.25f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.25f, 0.25f, 1.0f);

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            ClearAllArrows();
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

        if (arrowList.Count >= maxArrows)
        {
            GameObject oldestArrow = arrowList.Dequeue();
            if (oldestArrow != null)
            {
                Destroy(oldestArrow);
            }
        }

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        GameObject arrow = Instantiate(ArrowPrefab, transform.position + (Vector3)(direction * 0.1f), Quaternion.identity);

        arrow.GetComponent<ArrowScript>().SetDirection(direction);

        arrowList.Enqueue(arrow);
    }
    
    private void ClearAllArrows()
{
    foreach (GameObject arrow in arrowList)
    {
        if (arrow != null)
            Destroy(arrow);
    }
    arrowList.Clear();
}
}
