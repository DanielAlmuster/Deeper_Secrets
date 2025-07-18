using UnityEngine;

public class Life : MonoBehaviour
{
    public Seeker_Life seeker;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seeker"))
        {
            seeker.WinLife();
            Destroy(this.gameObject);
        }

    }
}
