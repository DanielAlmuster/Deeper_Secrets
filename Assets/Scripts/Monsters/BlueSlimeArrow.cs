using UnityEngine;

public class BlueSlimeArrow : MonoBehaviour
{
    public Seeker_Life seekerLife;
        void Start()
        {
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
            if (other.gameObject.CompareTag("Ground"))
            {
                Destroy(this.gameObject);
            }
            if (other.gameObject.CompareTag("FireArrow"))
            {
                Destroy(this.gameObject);
            }
        }
}
