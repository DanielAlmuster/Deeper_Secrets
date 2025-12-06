using UnityEngine;
using UnityEngine.SceneManagement;

public class Seeker_Life : MonoBehaviour
{
    public GameManager hud;
    public Seeker_Movement seekerMovement;
    private int lifes = 3;
    private Animator animator;


    void Start()
    {
        seekerMovement = GetComponent<Seeker_Movement>();
        animator = GetComponent<Animator>();
    }
    public void LoseLife()
    {
        lifes -= 1;
        if (lifes == 0)
        {
            seekerMovement.Death = true;
            animator.SetBool("Death", true);
        }
        if (lifes < 0)
        {
            return;
        }

        hud.LoseLife(lifes);
    }

    public void WinLife()
    {
        hud.WinLife(lifes);
        lifes += 1;
    }

    private void Respawn()
{
    transform.position = GetComponent<Seeker_Movement>().respawnPoint;
}
}
