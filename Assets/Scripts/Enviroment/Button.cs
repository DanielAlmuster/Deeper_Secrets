using UnityEngine;

public class Button : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public GameObject wall;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Seeker"))
        {
            Destroy(wall);
            SpriteRenderer sr = rigidbody2D.GetComponent<SpriteRenderer>();
            sr.color = Color.black;
        }
    }
    
}
