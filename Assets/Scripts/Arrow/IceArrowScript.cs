using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceArrowScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    private Vector2 velocity;
    public AudioClip Sound;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.linearVelocity = Direction * Speed;
        Rigidbody2D.gravityScale = 0.2f;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    void Update()
    {
        if (Rigidbody2D.linearVelocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(Rigidbody2D.linearVelocity.y, Rigidbody2D.linearVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterTile"))
        {
            Rigidbody2D.linearVelocity = Vector2.zero;
            Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            Rigidbody2D.freezeRotation = true;
            Destroy(this);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }    
    }


}
