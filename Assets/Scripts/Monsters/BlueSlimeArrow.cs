using UnityEngine;

public class BlueSlimeArrow : MonoBehaviour
{
    public Seeker_Life seekerLife;
    public AudioClip shootSound;
        void Start()
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);
            GameObject seeker = GameObject.FindWithTag("Seeker");
            seekerLife = seeker.GetComponent<Seeker_Life>();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Seeker"))
            {
                Vector2 damageDirection = new Vector2(transform.position.x, 0);
                other.gameObject.GetComponent<Seeker_Movement>().gettingDamage(damageDirection);
                seekerLife.LoseLife();
                Destroy(this.gameObject);
            }
            if (other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("BurneableBush")||other.gameObject.CompareTag("FireArrow"))
            {
                Destroy(this.gameObject);
            }
            
        }
}
