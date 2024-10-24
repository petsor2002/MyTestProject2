using UnityEngine;

public class PivotCamera : MonoBehaviour
{
    // Sensitivity variables
    public float sensX = 500f;
    public float sensY = 500f;

    public float smoothTime = 0.1f;

    // Private variables, our targets for the camera
    float xTarget;
    float yTarget;

    float xCurrent;
    float yCurrent;

    float xCurrentVelocity;
    float yCurrentVelocity;


    void Start()
    {
        // Vi vill inte att kameran börjar med att balla ur
        xTarget = xCurrent;
        yTarget = yCurrent;
    }

    
    void Update()
    {
        // Vi multiplicerar musens position med Tid, för at den skall gå på tid istället för FPS, och med vår Sensitivityvariabel. 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // När musens knapp trycks ned så vill vi att pekaren blir osynlig, inte rör sig och vi kan ändra variablerna för kamerans position
        if (Input.GetMouseButton(0))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            xTarget += mouseX;
            yTarget += mouseY;
        }
        else
        // Annars vill vi att den beter sig normalt. 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        // Dämparfunktionen SmoothDamp använder target och current för att räkna ut var kameran är och vart den borde röra sig. 
        xCurrent = Mathf.SmoothDamp(xCurrent, xTarget, ref xCurrentVelocity, smoothTime);
        yCurrent = Mathf.SmoothDamp(yCurrent, yTarget, ref yCurrentVelocity, smoothTime);

        // Sätt kamerans transform-properties till våra variabler. 
        transform.eulerAngles = new Vector3(-yCurrent, xCurrent, 0f);
    }
}
