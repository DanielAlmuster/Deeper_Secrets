using UnityEngine;

public class Life : MonoBehaviour
{
    public Seeker_Life seeker;
    public GameObject Seeker;
    public AudioClip collectSound;

    private void Start()
        {
            Seeker = GameObject.FindWithTag("Seeker");
            seeker = Seeker.GetComponent<Seeker_Life>();
        }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seeker"))
        {
            seeker.WinLife();
            Destroy(this.gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(collectSound);
        }

    }
}
