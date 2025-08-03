using UnityEngine;

public class SpikesTraps : MonoBehaviour
{
    public Seeker_Life seekerLife;
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
