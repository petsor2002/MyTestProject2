using UnityEngine;
using UnityEngine.Events;

public class TurnOnGraveText : MonoBehaviour
{
    public new Transform camera;
    public float reach = 5f;

    public UnityEvent onPressed;

    float pressMeHarder = 0;
    bool pressed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pressMeHarder < Mathf.Epsilon)
        {
            // spara knapptryckstatus i en variabel
            pressed = TryPress();

            if (pressed)
            {
                onPressed?.Invoke();
            }
        }

    }
    bool TryPress()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(camera.position, camera.forward);

        //Träffar vi något?
        if (!Physics.Raycast(ray, out hitInfo, reach))
            return false;

        Debug.Log(hitInfo.collider.gameObject.name);
        //Är det vi träffade något annat än knappen?
        if (hitInfo.collider != gameObject.GetComponent<Collider>())
            return false;
        //Om bägge de ovan är falska, så måste det ju vara knappen vi träffade.
        return true;

    }

}

