using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject[] vidas;
    public GameObject powerSelector;
    public Sprite EmptyLife;
    public Sprite FullLife;
    public Sprite NormalArrow;
    public Sprite FireArrow;
    public Sprite IceArrow;


    public void LoseLife(int indice)
    {
        vidas[indice].GetComponent<Image>().sprite = EmptyLife;
    }
    public void WinLife(int indice)
    {
        vidas[indice].GetComponent<Image>().sprite = FullLife;
    }

    public void changePowerNormal()
    {
        powerSelector.GetComponent<Image>().sprite = NormalArrow;
    }
    public void changePowerFire()
    {
        powerSelector.GetComponent<Image>().sprite = FireArrow;
    }
    public void changePowerIce()
    {
        powerSelector.GetComponent<Image>().sprite = IceArrow;
    }
}
