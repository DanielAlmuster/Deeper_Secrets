using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Seeker_Movement : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public GameObject FireArrowPrefab;
    private Seeker_Powers playerPowers;
    private GameManager gameManager;
    public float Speed;
    public float JumpForce;
    public float KnockbackForce;
    private bool Grounded;
    private bool Damage = false;
    public bool Death = false;
    private Rigidbody2D RigidBody2D;
    private Animator Animator;
    private float Horizontal;
    private Queue<GameObject> arrowList = new Queue<GameObject>();
    private int maxArrows = 3;

    public float fireCooldown = 2f;
    private float fireTimer = 0f;
    public AudioClip reloadSound;
    public AudioClip hurtSound;

    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

        RigidBody2D.freezeRotation = true;

        playerPowers = GetComponent<Seeker_Powers>();
    }

    void Update()
    {
        if (Death)
        {
            RigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            RigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionY;  
            RigidBody2D.freezeRotation = true;
        }
        if(Death==false)
        {
        if (fireTimer > 0)
        fireTimer -= Time.deltaTime;

        //Cambio de sprite
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-0.25f, 0.25f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.25f, 0.25f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f&&Grounded);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.4f))
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
            if (playerPowers.actualPower == "Leaf")
            {
                Shoot();
            }
            if (playerPowers.actualPower == "Fire" && fireTimer <= 0f)
            {
                ShootFire();
                fireTimer = fireCooldown;
            }
            if (playerPowers.actualPower == "Ice")
            {
                ShootIce();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerPowers.ChangePower(1f);
            gameManager.changePowerNormal();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && playerPowers.FireActive == true)
        {
            playerPowers.ChangePower(2f);
            gameManager.changePowerFire();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && playerPowers.IceActive == true)
        {
            playerPowers.ChangePower(3f);
            gameManager.changePowerIce();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (arrowList.Count>0){
                Camera.main.GetComponent<AudioSource>().PlayOneShot(reloadSound);
            }
            ClearAllArrows();
        }
    }
}
    private void FixedUpdate()
    {
        RigidBody2D.linearVelocity = new Vector2(Horizontal * Speed, RigidBody2D.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("FirePowerUp"))
            {
                playerPowers.ActiveFireArrows();
            }
            if (other.gameObject.CompareTag("IcePowerUp"))
            {
                playerPowers.ActiveIceArrows();
            }
            if (other.gameObject.CompareTag("Arrow")||Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
        }
    private void Jump()
    {
        Animator.SetBool("Jumping", true);
        RigidBody2D.AddForce(Vector2.up * JumpForce);

    }

    private void JumpOff()
    {
        Animator.SetBool("Jumping", false);
    }
    
    public void LoseGame()
    {
        SceneManager.LoadScene(0);
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

        GameObject arrow = Instantiate(ArrowPrefab, transform.position + (Vector3)(direction * 0.8f), Quaternion.identity);

        arrow.GetComponent<ArrowScript>().SetDirection(direction);

        arrowList.Enqueue(arrow);



    }

    private void ShootFire()
    {

        if (arrowList.Count >= 1)
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

        GameObject arrow = Instantiate(FireArrowPrefab, transform.position + (Vector3)(direction * 0.8f), Quaternion.identity);

        arrow.GetComponent<FireArrowScript>().SetDirection(direction);

        arrowList.Enqueue(arrow);

        

    }

    private void ShootIce()
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

        GameObject arrow = Instantiate(ArrowPrefab, transform.position + (Vector3)(direction * 0.8f), Quaternion.identity);

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

    public void gettingDamage(Vector2 direction)
    {
        if (!Damage)
        {
            Damage = true;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(hurtSound);
            Animator.SetBool("Damage", true);
            Vector2 knockback = new Vector2(transform.position.x - direction.x, 1).normalized;
            RigidBody2D.AddForce(knockback * KnockbackForce, ForceMode2D.Impulse);
        }
    }

    public void gettingDamageOff()
    {
        Damage = false;
        Animator.SetBool("Damage", false);
    }
}
