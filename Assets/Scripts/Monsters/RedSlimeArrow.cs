using UnityEngine;

public class RedSlimeArrow : MonoBehaviour
{
    public Seeker_Life seekerLife;
    public AudioClip shootSound;
    bool Frozen = false;
    private Rigidbody2D rb;
        void Start()
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);
            GameObject seeker = GameObject.FindWithTag("Seeker");
            seekerLife = seeker.GetComponent<Seeker_Life>();
            rb = GetComponent<Rigidbody2D>();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Seeker")&&!Frozen)
            {
                Vector2 damageDirection = new Vector2(transform.position.x, 0);
                other.gameObject.GetComponent<Seeker_Movement>().gettingDamage(damageDirection);
                seekerLife.LoseLife();
                Destroy(this.gameObject);
            }
            if (other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("BurneableBush"))
            {
                Destroy(this.gameObject);
            }
            if (other.gameObject.CompareTag("EnemyFireArrow")&&Frozen)
            {
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("IceArrow"))
            {
                Frozen = true;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;  
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                rb.freezeRotation = true;
                Destroy(other.gameObject);
                Invoke("DestroyArrow", 10f);
            }
        }
        
    void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
