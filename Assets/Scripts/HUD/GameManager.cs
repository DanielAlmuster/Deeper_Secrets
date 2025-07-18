using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject[] vidas;
    public Sprite EmptyLife;
    public Sprite FullLife;

    void Update()
    {

    }

    public void LoseLife(int indice)
    {
        vidas[indice].GetComponent<Image>().sprite = EmptyLife;
    }
    public void WinLife(int indice)
    {
        vidas[indice].GetComponent<Image>().sprite = FullLife;
    }
}
