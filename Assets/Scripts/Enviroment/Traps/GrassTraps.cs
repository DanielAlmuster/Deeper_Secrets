using UnityEngine;

public class Traps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Seeker")||(other.gameObject.CompareTag("Arrow")))
            {
                Destroy(this.gameObject);
            }
        }
}
