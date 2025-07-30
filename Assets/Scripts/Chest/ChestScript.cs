using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject fireArrowPickUp;
    private Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seeker"))
        {
            Animator.SetBool("Open", true);
        }
    }

    private void ItemDrop()
    {
        GameObject fireArrow = Instantiate(fireArrowPickUp, transform.position , Quaternion.identity);
    }
}
