using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlime : MonoBehaviour
{
    public GameObject Seeker;
    private Rigidbody2D rb;
    private float jumpTimer = 2f;
    public float jumpForce;
    public Seeker_Life seekerLife;
    public float detectionRadius = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //Se resta la posicion de este objeto con la del seleccionado para que vea para ese objeto
        Vector3 direction = Seeker.transform.position - transform.position;
        if (direction.x < 0.0f) transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        else if (direction.x > 0.0f) transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0f)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Seeker.transform.position);
            if (distanceToPlayer < detectionRadius)
            {
                JumpToSeeker();
                jumpTimer = 2f;
            }
        }
    }

    private void JumpToSeeker()
    {
        float directionX = Mathf.Sign(Seeker.transform.position.x - transform.position.x);

        Vector2 jumpDirection = new Vector2(directionX, 1f).normalized;

        rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }

    //Other hace referencia al objeto con el que choca
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Seeker"))
        {
            Vector2 damageDirection = new Vector2(transform.position.x, 0);
            other.gameObject.GetComponent<Seeker_Movement>().gettingDamage(damageDirection);
            seekerLife.LoseLife();
        }
    }
}
