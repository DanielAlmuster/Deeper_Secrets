using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {

    }
    void FixedUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seeker"))
        {
            Animator.SetBool("Open", true);
            Debug.Log("aaa");
        }
    }
}
