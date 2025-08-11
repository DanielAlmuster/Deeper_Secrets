using UnityEngine;

public class Burneab : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("FireArrow"))
            {
                Destroy(this.gameObject);
            }
        }
}
