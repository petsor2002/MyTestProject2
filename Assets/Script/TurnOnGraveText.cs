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

        //Tr�ffar vi n�got?
        if (!Physics.Raycast(ray, out hitInfo, reach))
            return false;

        Debug.Log(hitInfo.collider.gameObject.name);
        //�r det vi tr�ffade n�got annat �n knappen?
        if (hitInfo.collider != gameObject.GetComponent<Collider>())
            return false;
        //Om b�gge de ovan �r falska, s� m�ste det ju vara knappen vi tr�ffade.
        return true;

    }

}

