using UnityEngine;

public class Door : MonoBehaviour
{
    //dörren är stängd
    public bool closed = true;
    public bool mirror = false;

    public float openedDegrees = 90f;
    public float openSpeed = 60f;

    float closedDegrees;

    Vector3 closedEulerAngles;
    Vector3 openedEulerAngles;
    


    void Start()
    {
        closedDegrees = transform.localEulerAngles.y;

        closedEulerAngles = new Vector3(0f, closedDegrees, 0f);
        if (mirror)
            openedEulerAngles = new Vector3(0f, closedDegrees - openedDegrees, 0f);
        else
            openedEulerAngles = new Vector3(0f, closedDegrees + openedDegrees, 0f);
    }

    void Update()
    {
        if (closed)
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, closedEulerAngles, openSpeed * Time.deltaTime);
            
        else
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, openedEulerAngles, openSpeed * Time.deltaTime);
    }

    public void ToggleOpen() 
    { 
        closed = !closed;
    
    
    }
}


