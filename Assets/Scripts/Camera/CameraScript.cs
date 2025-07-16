using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Seeker;

    void Update()
    {
        if (Seeker.transform.position.x>3.5f)
        {
        Vector3 position = transform.position;
        position.x = Seeker.transform.position.x;
        position.y = Seeker.transform.position.y+ 1.5f;
        transform.position = position;
        }
    }
}
