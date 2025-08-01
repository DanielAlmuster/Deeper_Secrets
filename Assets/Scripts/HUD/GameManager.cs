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
    Debug.Log("powerSelector is null? " + (powerSelector == null));
    if (powerSelector != null)
    {
        Image img = powerSelector.GetComponent<Image>();
        Debug.Log("Image component is null? " + (img == null));
        if (img != null)
        {
            img.sprite = NormalArrow;
            Debug.Log("Sprite changed!");
        }
        else
        {
            Debug.LogError("No Image component found!");
        }
    }
    else
    {
        Debug.LogError("powerSelector is not assigned!");
    }
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
