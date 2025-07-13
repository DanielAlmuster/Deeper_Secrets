using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Seeker;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Seeker.transform.position.x;
        position.y = Seeker.transform.position.y;
        transform.position = position;
        
    }
}
