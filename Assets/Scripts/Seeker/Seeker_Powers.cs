using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Seeker_Powers : MonoBehaviour
{
    public List<string> powers = new List<string>();
    public string actualPower = "Leaf";
    public bool FireActive = false;
    public bool IceActive = false;
    void Start()
    {
        powers.Add("Leaf");
        powers.Add("Fire");
        powers.Add("Ice");
    }

    public void ChangePower(float power)
    {
        if (power == 1)
        {
            actualPower = powers[0];
        }
        if (power == 2)
        {
            actualPower = powers[1];
        }
        if (power == 3)
        {
            actualPower = powers[2];
        }
    }
    

    public void ActiveFireArrows()
    {
        FireActive = true;
    }

    public void ActiveIceArrows()
    {
        IceActive = true;
    }

    public void DesactiveFireArrows()
    {
        FireActive = false;
    } 

    public void DesactiveIceArrows()
    {
        IceActive = false;
    }
}
