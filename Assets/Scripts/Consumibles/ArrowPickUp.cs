using UnityEngine;

public class ArrowPickUp : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float dropForce = 5;
    public AudioClip pickupSound;
    private bool canPickUp = false;
    private float timer = 1f;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
        rigidbody2D.freezeRotation = true;
    }
    
    void Update()
    {
        if (!canPickUp)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                canPickUp = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seeker")&&canPickUp)
        {
            Destroy(this.gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(pickupSound);
        }
        if (other.CompareTag("Ground"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
