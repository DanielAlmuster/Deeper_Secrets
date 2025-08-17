using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlime : MonoBehaviour
{
    public GameObject Seeker;
    private Rigidbody2D rb;
    private float shootTimer = 2f;
    public float shootForce;
    public Seeker_Life seekerLife;
    public float detectionRadius = 5.0f;
    public GameObject projectilePrefab; 
    public Transform firePoint; 


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

        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Seeker.transform.position);
            if (distanceToPlayer < detectionRadius)
            {
                ShootToSeeker();
                shootTimer = 2f;
            }
        }
    }

   private void ShootToSeeker()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D projRb = projectile.GetComponent<Rigidbody2D>();

        Vector2 direction = (Seeker.transform.position - firePoint.position).normalized;

        projRb.linearVelocity = direction * shootForce;

        //Funcion para rotar el proyectil al lugar del jugador
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
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
