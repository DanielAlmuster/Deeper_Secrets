using UnityEngine;

public class Burneab : MonoBehaviour
{
    public AudioClip burnSound;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FireArrow"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(burnSound);
        }
    }
}
