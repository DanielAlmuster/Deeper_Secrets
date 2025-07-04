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
        Rigidbody2D.velocity = Direction * Speed;


    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyArrow()
    {
        Destroy(gameObject);
    }

}
