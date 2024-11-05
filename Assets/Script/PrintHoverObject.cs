using UnityEngine;

public class PrintHoverObject : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
