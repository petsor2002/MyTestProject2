using System.Runtime.CompilerServices;
using UnityEngine;


public class WhosGraveisThis : MonoBehaviour
{

    public Camera cam;
    public float length = 5f;

    Material mat;
    Material originalMat;

    Collider checkCollider;



    void Start()
    {
        checkCollider = GetComponent<Collider>();
        mat = GetComponent<MeshRenderer>().material;
        originalMat = mat;
    }

    void Update()
    {
        RaycastHit hitinfo;
        Ray hitRay = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * length, Color.cyan);

        // Kolla om kameran �r riktad mot objektet
        if (checkCollider.Raycast(hitRay, out hitinfo, length))
        {
            // Om kameran riktad mot objektet, aktivera asset

            // Asset �r '�ndra materialets _Lightup till 1' och 'Text: "Who's grave is this?"' med symbol 'E'
            mat.SetFloat("_Lightup", 1f);
            Debug.Log("NEW");

            // T�nd UI
            UIManager.instance.ShowCanvas(true);

            // Annars s�tt _Lightup till 0 och sl�ck UI
        }
        else
        {
            mat.SetFloat("_Lightup", 0f);
            UIManager.instance.ShowCanvas(false);
            Debug.Log("OLD");
        }

    }
}
