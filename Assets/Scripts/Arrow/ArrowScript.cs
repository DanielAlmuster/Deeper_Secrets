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
    }

    void Update()
    {
        Rigidbody2D.linearVelocity = Direction * Speed;


    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyArrow()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.collider.CompareTag("Terreno"))
    {
        Rigidbody2D.linearVelocity = Vector2.zero;
        Rigidbody2D.bodyType = RigidbodyType2D.Kinematic; 
        Rigidbody2D.freezeRotation = true;
        Destroy(this); 
    }
    if (collision.collider.CompareTag("Flecha"))
    {
            DestroyArrow(); 
    }
}


}
