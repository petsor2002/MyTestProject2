using UnityEngine;

public class Look_3rd_person_camera : MonoBehaviour
{
    public Transform cameraFocus;
    public Vector3 offset;

    void Start()
    {
        
    }


    void Update()
    {
        transform.LookAt(cameraFocus);
        transform.position = Vector3.Lerp(transform.position, cameraFocus.position + offset, 0.8f * Time.deltaTime);
    }
}
