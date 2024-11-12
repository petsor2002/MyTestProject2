using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject objectToDestroy;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Destroy(objectToDestroy);
        }
    }
}
