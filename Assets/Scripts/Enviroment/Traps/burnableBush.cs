using UnityEngine;

public class Burneab : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("FireArrow"))
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
}
