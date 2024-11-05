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

        // Kolla om kameran är riktad mot objektet
        if (checkCollider.Raycast(hitRay, out hitinfo, length))
        {
            // Om kameran riktad mot objektet, aktivera asset

            // Asset är 'Ändra materialets _Lightup till 1' och 'Text: "Who's grave is this?"' med symbol 'E'
            mat.SetFloat("_Lightup", 1f);
            Debug.Log("NEW");

            // Tänd UI
            UIManager.instance.ShowCanvas(true);

            // Annars sätt _Lightup till 0 och släck UI
        }
        else
        {
            mat.SetFloat("_Lightup", 0f);
            UIManager.instance.ShowCanvas(false);
            Debug.Log("OLD");
        }

    }
}
