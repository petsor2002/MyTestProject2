using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public new Transform camera;
    public float reach = 4f;

    public UnityEvent onPressed;

    public float pressDepth = 2f;
    public float speed = 0.3f;
    float pressMeHarder = 0;
    bool pressed = false;


    [SerializeField] Vector3 buttonOrgLocalPos;
    private void Start()
    {
        buttonOrgLocalPos = transform.localPosition;
    }


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

        if (pressed)
        {
            if (pressMeHarder < 0.5f)
                transform.localPosition -=  Vector3.up * speed * Time.deltaTime;
            else
                transform.localPosition +=  Vector3.up * speed * Time.deltaTime;

            pressMeHarder += Time.deltaTime;

            if (pressMeHarder >= 1)
            {
                transform.localPosition = buttonOrgLocalPos;
                pressMeHarder = 0;
                pressed = false;
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
        //Är det vi träffade något annat än knappen?
        if (hitInfo.collider != gameObject.GetComponent<Collider>())
            return false;
        //Om bägge de ovan är falska, så måste det ju vara knappen vi träffade.
        return true;

    }

}
