using UnityEngine;

public class FireArrowPickUp : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float dropForce = 5;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
        rigidbody2D.freezeRotation = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seeker"))
        {
            Destroy(this.gameObject);
        }

    }
}
