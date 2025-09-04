using UnityEngine;

public class KingSlime : MonoBehaviour
{

    private BlueSlime blueSlime;
    private RedSlime redSlime;
    private GreenSlime greenSlime;
    private Animator Animator;
    public RuntimeAnimatorController[] animationVariants;

    private void Start()
    {
        Animator = GetComponent<Animator>();

        blueSlime = GetComponent<BlueSlime>();
        redSlime = GetComponent<RedSlime>();
        greenSlime = GetComponent<GreenSlime>();

        blueSlime.enabled = false;
        redSlime.enabled = false;
        greenSlime.enabled = false;

        InvokeRepeating("randomScript", 0f, 10f);
    }

    private void randomScript()
    {
        blueSlime.enabled = false;
        redSlime.enabled = false;
        greenSlime.enabled = false;

        int randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            blueSlime.enabled = true;
            Animator.runtimeAnimatorController = animationVariants[2];
        }
        if (randomNumber == 2)
        {
            redSlime.enabled = true;
            Animator.runtimeAnimatorController = animationVariants[1];
        }
        if (randomNumber == 3)
        {
            greenSlime.enabled = true;
            Animator.runtimeAnimatorController = animationVariants[0];
        }
    }
}
