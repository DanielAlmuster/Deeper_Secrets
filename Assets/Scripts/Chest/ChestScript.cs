using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject PickUp;
    private Animator Animator;
    public AudioClip openSound;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seeker")&&!Animator.GetBool("Open"))
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(openSound);
            Animator.SetBool("Open", true);
        }
    }

    private void ItemDrop()
    {
        GameObject pickUp = Instantiate(PickUp, transform.position , Quaternion.identity);
    }
}
