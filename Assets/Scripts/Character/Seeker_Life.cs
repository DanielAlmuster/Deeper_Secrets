using UnityEngine;

public class Seeker_Life : MonoBehaviour
{
    public GameManager hud;
    private int lifes = 3;

    public void LoseLife()
    {
        lifes -= 1;
        hud.LoseLife(lifes);
    }

    public void WinLife()
    {
        hud.WinLife(lifes);
        lifes += 1;
    }
}
