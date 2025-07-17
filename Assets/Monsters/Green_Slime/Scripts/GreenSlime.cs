using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlime : MonoBehaviour
{
    public GameObject Seeker;

    private void Update()
    {
        //Se resta la posicion de este objeto con la del seleccionado para que vea para ese objeto
        Vector3 direction = Seeker.transform.position - transform.position;
        if (direction < 0.0f) transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        else if (direction > 0.0f) transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
    }
}
