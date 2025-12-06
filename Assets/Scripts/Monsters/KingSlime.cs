using UnityEngine;

public class KingSlime : MonoBehaviour
{

    private BlueSlime blueSlime;
    private RedSlime redSlime;
    private GreenSlime greenSlime;
    private Animator Animator;
    public RuntimeAnimatorController[] animationVariants;
    private MenuController menuController;

    private void Start()
    {
        Animator = GetComponent<Animator>();

        blueSlime = GetComponent<BlueSlime>();
        redSlime = GetComponent<RedSlime>();
        greenSlime = GetComponent<GreenSlime>();

        blueSlime.enabled = false;
        redSlime.enabled = false;
        greenSlime.enabled = false;

        menuController = FindAnyObjectByType<MenuController>();

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

    private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("LavaTile"))
            {
                Debug.Log("Aaa");
                menuController.Win();
            }
        }
}
